using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_A.Architecture
{
    public class ClienteA : IClienteA
    {
        private HubConnection connection;
        private bool _cerrar = false;
        public  ClienteA()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/channel")
                .Build();
            connection.StartAsync();
            
        }
        public void cerrar()
        {
            _cerrar = true;
        }
        
        public IObservable<T> CloudFunction<T>() where T : class
        {
            
            var observer = Observable.Create<T>(observer =>
            {
                
                connection.On<T>("ReceiveMessage", (s) => 
                {
                    try
                    {
                        observer.OnNext(s);

                    }
                    catch (Exception e)
                    {
                        observer.OnError(e);
                    }
                    finally
                    {
                        Dipose(observer);
                    }
                    
                });
                return () =>{ };
            });
            return observer;
        }

        private void Dipose<T>(IObserver<T> observer)
        {
            if (_cerrar)
            {
                observer.OnCompleted();
            }
        }

    }
}
