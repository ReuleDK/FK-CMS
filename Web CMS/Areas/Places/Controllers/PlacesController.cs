using System.Web.Mvc;
using Web_CMS.App_Code;

namespace Web_CMS.Areas.Places {
    public class PlacesController : Controller {
        [CustomAuthorize]
        public ActionResult Index() { 
            return View(); 
        }
    }
}