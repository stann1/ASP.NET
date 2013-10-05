using System.Web.Mvc;

namespace _03.Bookstore.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

           context.MapRoute(
                name: "Edit User",
                url: "Administration/Users/{action}",
                defaults: new { controller = "Users" }
                );


            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}