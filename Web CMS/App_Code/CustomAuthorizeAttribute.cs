using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_CMS.App_Code
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params string[] roles)
        {

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new HttpException(404, "Not Found");
            }
        }
    }
}
