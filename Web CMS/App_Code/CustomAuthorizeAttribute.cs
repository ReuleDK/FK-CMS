using System.Web.Mvc;
using System.Web.Routing;

namespace Web_CMS.App_Code
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(403);
            }
            //user is not authenticated
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Admin" }));
        }
    }
}
