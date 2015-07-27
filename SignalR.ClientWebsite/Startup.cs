using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalR.ClientWebsite.Startup))]
namespace SignalR.ClientWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/signalr",new HubConfiguration());
            ConfigureAuth(app);
        }
    }
}
