using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ModestTree;
using ModestTree.Util;

namespace Zenject
{
    // Five Parameters
    public abstract class Signal<TDerived, TParam1, TParam2, TParam3, TParam4, TParam5> : ISignal
        where TDerived : Signal<TDerived, TParam1, TParam2, TParam3, TParam4, TParam5>
    {
        readonly List<ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5>> _listeners = new List<ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5>>();

        bool _hasDisposed;

        public void Listen(ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5> listener)
        {
            Assert.That(!_listeners.Contains(listener),
                () => "Tried to add method '{0}' to signal '{1}' but it has already been added"
                .Fmt(listener.ToDebugString(), this.GetType().Name));
            _listeners.Add(listener);
        }

        public void Unlisten(ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5> listener)
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

        public static TDerived operator + (Signal<TDerived, TParam1, TParam2, TParam3, TParam4, TParam5> signal, ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5> listener)
        {
            signal.Listen(listener);
            return (TDerived)signal;
        }

        public static TDerived operator - (Signal<TDerived, TParam1, TParam2, TParam3, TParam4, TParam5> signal, ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5> listener)
        {
            signal.Unlisten(listener);
            return (TDerived)signal;
        }

        public void Fire(TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4, TParam5 p5)
        {
            // Use ToArray in case they remove in the handler
            foreach (var listener in _listeners.ToArray())
            {
                listener(p1, p2, p3, p4, p5);
            }
        }
    }
}
