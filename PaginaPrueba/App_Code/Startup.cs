using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaginaPrueba.Startup))]
namespace PaginaPrueba
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
