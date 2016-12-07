using System;

namespace Zenject
{
    public static class SignalExtensions
    {
        public static void BindSignal<TSignal>(this DiContainer container)
            where TSignal : ISignal
        {
            container.Bind<TSignal>().AsSingle();

            // Uncomment this if you want to see warnings when the signal is destroyed and
            // there are still listeners on it
            //container.Bind<ILateDisposable>().To<TSignal>().AsSingle();
        }

        public static void BindSignal<TSignal>(this DiContainer container, string identifier)
            where TSignal : ISignal
        {
            container.Bind<TSignal>().WithId(identifier).AsSingle(identifier);

            // Uncomment this if you want to see warnings when the signal is destroyed and
            // there are still listeners on it
            //container.Bind<ILateDisposable>().To<TSignal>().FromResolve(identifier);
        }
    }
}
