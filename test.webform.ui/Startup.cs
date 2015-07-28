using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(test.webform.ui.Startup))]
namespace test.webform.ui
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
