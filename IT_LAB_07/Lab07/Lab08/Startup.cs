using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab08.Startup))]
namespace Lab08
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
