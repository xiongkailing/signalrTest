using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.ClientWebsite
{
    [HubName("signalrTest")]
    public class SignalRHub : Hub
    {
        public override Task OnConnected()
        {
            var name = Context.QueryString["name"];
            if (!string.IsNullOrEmpty(name))
            {
                this.Hello(name);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.QueryString["name"];
            if (!string.IsNullOrEmpty(name))
            {
                this.Byebye(name);
            }
            else
            {
                this.Byebye("console exe");
            }
            return base.OnDisconnected(stopCalled);
        }
        public void Hello(string name)
        {
            Clients.All.hello(name);//客户端需要声明hello函数
        }

        public void Byebye(string name)
        {
            Clients.All.byebye(name);
        }
        public void SayMessage(string message)
        {
            Clients.Others.getMessage("console exe", message);
        }
    }
}