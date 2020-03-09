using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente_A.Architecture
{
    interface IClienteA
    {
        IObservable<T> CloudFunction<T>() where T : class;
    }
}
