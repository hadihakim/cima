using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cima.Startup))]
namespace cima
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
