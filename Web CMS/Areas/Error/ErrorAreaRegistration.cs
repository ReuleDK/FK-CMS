using System.Web.Mvc;

namespace Web_CMS.Areas.Error {
    public class ErrorAreaRegistration : AreaRegistration {
        public override string AreaName { get { return "Error"; } }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Error_default",
                "{controller}/{action}/{id}",
                new { controller = "Error", action = "HttpError404", id = UrlParameter.Optional }
            );
        }
    }
}