using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroupaBull.Startup))]
namespace GroupaBull
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
