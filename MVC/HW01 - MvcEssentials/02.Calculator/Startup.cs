using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.Calculator.Startup))]
namespace _02.Calculator
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
