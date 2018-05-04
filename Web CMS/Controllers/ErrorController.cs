using System.Web.Mvc;

namespace Web_CMS.Controllers {
    public class ErrorController : Controller {
        public ActionResult HttpError403(string message) {
            return View("~/Views/Error/UnauthorizedAccess.cshtml", model:message);
        }
        public ActionResult HttpError404(string message) {
            string test = System.Web.HttpContext.Current.Server.MapPath("~/Views/Error/NotFound.cshtml");
            return View("~/Views/Error/NotFound.cshtml", model:message);
        }
        public ActionResult HttpError500(string message) {
            return View("~/Views/Error/ServerError.cshtml", model:message);
        }
    }
}