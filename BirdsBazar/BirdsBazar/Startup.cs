using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BirdsBazar.Startup))]
namespace BirdsBazar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
