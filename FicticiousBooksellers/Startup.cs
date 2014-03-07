using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FicticiousBooksellers.Startup))]
namespace FicticiousBooksellers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
