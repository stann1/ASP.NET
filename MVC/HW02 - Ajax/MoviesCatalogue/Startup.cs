using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesCatalogue.Startup))]
namespace MoviesCatalogue
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
