using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_10_mvc_auth.Startup))]
namespace Lab_10_mvc_auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
