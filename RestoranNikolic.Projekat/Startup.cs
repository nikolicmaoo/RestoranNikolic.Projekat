using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestoranNikolic.Projekat.Startup))]
namespace RestoranNikolic.Projekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
