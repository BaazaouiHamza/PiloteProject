using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HazemPFE.Startup))]
namespace HazemPFE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
