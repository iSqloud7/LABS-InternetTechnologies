using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Albums.Startup))]
namespace Albums
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
