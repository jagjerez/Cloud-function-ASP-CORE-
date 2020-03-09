using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente_A.Architecture.Interfaces
{
    interface IPublicador
    {
        IObservable<T> Notificar<T>();
        IObservable<T> Notificar<T>(T valor);

        IObservable<T> Notificar<T>(string valor ...);
    }
}
