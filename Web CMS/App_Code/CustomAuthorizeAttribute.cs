using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EntityCms;

namespace Web_CMS.App_Code {
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute {      
		public CustomAuthorizeAttribute(params Roles[] roles) { UserRoles = roles; }

		public override void OnAuthorization(AuthorizationContext filterContext) {
			int[] roleNumbers = UserRoles.Cast<int>().ToArray();
            
			try {
				string userName = "";
				if(HttpContext.Current.Session == null || HttpContext.Current.Session["UserName"] == null){
					filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
					return;
				}
                userName = HttpContext.Current.Session["UserName"].ToString();
				bool authorized = AuthHelper.CheckUser(userName, roleNumbers);
				if (!authorized) throw new HttpException(403, "No right rights.");
			} catch (Exception e) {
				throw new HttpException(403, "Error concerning user rights. " + e.Message);
			}
        }
       
		public Roles[] UserRoles { get; set; }
    }
}