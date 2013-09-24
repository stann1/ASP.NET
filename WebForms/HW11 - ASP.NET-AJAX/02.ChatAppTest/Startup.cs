using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatAppTest.Startup))]
namespace ChatAppTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
