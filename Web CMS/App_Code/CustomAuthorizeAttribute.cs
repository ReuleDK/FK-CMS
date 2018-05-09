using System.Web;
using System.Web.Mvc;

namespace Web_CMS.App_Code {
    public class CustomAuthorizeAttribute : AuthorizeAttribute {
        public CustomAuthorizeAttribute(params string[] roles) { }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated) {
                throw new HttpException(403, "No right rights.");
            }
        }
    }
}