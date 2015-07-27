using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Message.Pusher
{
    class Program
    {
        static void Main(string[] args)
        {

            Start();
            //hubConnection.Start();
        }

        private static void Start()
        {
            var hubConnection = new HubConnection("http://localhost:56848/signalr");
            Console.WriteLine(hubConnection.State.ToString());
            IHubProxy signalrHubProxy = hubConnection.CreateHubProxy("signalrTest");
            hubConnection.Start().Wait();
            signalrHubProxy.Invoke("SayMessage", "this word is come from console exe");
        }
    }
}
