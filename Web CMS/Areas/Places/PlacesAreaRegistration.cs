using System.Web.Mvc;

namespace Web_CMS.Areas.Places {
    public class PlacesAreaRegistration : AreaRegistration {
        public override string AreaName { get { return "Places"; } }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Places_default",
                "{controller}/{action}/{id}",
                new { controller = "Places", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}