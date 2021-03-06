using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ModestTree;
using ModestTree.Util;
//using UniRx;

namespace Zenject
{
    // Three Parameters
    public abstract class Signal<TDerived, TParam1, TParam2, TParam3> : ISignal
        where TDerived : Signal<TDerived, TParam1, TParam2, TParam3>
    {
        readonly List<Action<TParam1, TParam2, TParam3>> _listeners = new List<Action<TParam1, TParam2, TParam3>>();
        //readonly Subject<ValuePair<TParam1, TParam2, TParam3>> _stream = new Subject<ValuePair<TParam1, TParam2, TParam3>>();

        bool _hasDisposed;

        //public IObservableRx<ValuePair<TParam1, TParam2, TParam3>> Stream
        //{
            //get
            //{
                //return _stream;
            //}
        //}

        public void Listen(Action<TParam1, TParam2, TParam3> listener)
        {
            Assert.That(!_listeners.Contains(listener),
                () => "Tried to add method '{0}' to signal '{1}' but it has already been added"
                .Fmt(listener.ToDebugString(), this.GetType().Name));
            _listeners.Add(listener);
        }

        public void Unlisten(Action<TParam1, TParam2, TParam3> listener)
        {
            bool success = _listeners.Remove(listener);
            Assert.That(success,
                () => "Tried to remove method '{0}' from signal '{1}' without adding it first"
                .Fmt(listener.ToDebugString(), this.GetType().Name));
        }

        void ILateDisposable.LateDispose()
        {
            Assert.That(!_hasDisposed, "Tried to dispose signal '{0}' twice", this.GetType().Name);
            _hasDisposed = true;

            // If you don't want to verify that all event handlers have been removed feel free to comment out this assert or remove
            Assert.Warn(_listeners.IsEmpty(),
                () => "Found {0} methods still added to signal '{1}'.  Methods: {2}"
                .Fmt(_listeners.Count, this.GetType().Name, _listeners.Select(x => x.ToDebugString()).Join(", ")));
        }

        public static TDerived operator + (Signal<TDerived, TParam1, TParam2, TParam3> signal, Action<TParam1, TParam2, TParam3> listener)
        {
            signal.Listen(listener);
            return (TDerived)signal;
        }

        public static TDerived operator - (Signal<TDerived, TParam1, TParam2, TParam3> signal, Action<TParam1, TParam2, TParam3> listener)
        {
            signal.Unlisten(listener);
            return (TDerived)signal;
        }

        public void Fire(TParam1 p1, TParam2 p2, TParam3 p3)
        {
            // Use ToArray in case they remove in the handler
            foreach (var listener in _listeners.ToArray())
            {
                listener(p1, p2, p3);
            }

            //_stream.OnNext(ValuePair.New(p1, p2, p3));
        }
    }
}
