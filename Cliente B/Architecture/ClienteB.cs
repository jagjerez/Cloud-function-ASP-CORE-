using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_B.Architecture
{
    class ClienteB
    {
        private HubConnection connection;
        public ClienteB()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/channel")
                .Build();
            
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        public async void sendMessage(string mensaje)
        {
            if(!(connection.State == HubConnectionState.Connected))
            {
                await connection.StartAsync();
            }
            await connection.InvokeAsync("SendMessage", mensaje);
            //await connection.StopAsync();
        }
    }
}
