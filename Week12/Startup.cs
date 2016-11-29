using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week12.Startup))]
namespace Week12
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
