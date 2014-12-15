using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTemplate.Startup))]
namespace WebTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
