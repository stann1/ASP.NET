using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03.Bookstore.Startup))]
namespace _03.Bookstore
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
