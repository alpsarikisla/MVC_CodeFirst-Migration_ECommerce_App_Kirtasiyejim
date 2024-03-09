using System.Web.Mvc;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel
{
    public class AdminManagerPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminManagerPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminManagerPanel_default",
                "AdminManagerPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}