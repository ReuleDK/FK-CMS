using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCms;

namespace Web_CMS.App_Code {
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute {      
		public CustomAuthorizeAttribute(params Roles[] roles) { UserRoles = roles; }

		protected override bool AuthorizeCore(HttpContextBase httpContext) {
            var userName = HttpContext.Current.Session["UserName"].ToString();
            
			int[] roleNumbers = UserRoles.Cast<int>().ToArray();
			bool authorized = AuthHelper.CheckUser(userName, roleNumbers);
			if (authorized) return true;
			throw new HttpException(403, "No right rights.");
        }
       
		public Roles[] UserRoles { get; set; }
    }
}