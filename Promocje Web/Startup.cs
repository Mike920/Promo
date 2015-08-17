using Microsoft.Owin;
using Owin;
using Promocje_Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Promocje_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
