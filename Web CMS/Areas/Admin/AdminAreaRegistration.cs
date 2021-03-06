﻿using System.Web.Mvc;

namespace Web_CMS.Areas.Admin {
    public class AdminAreaRegistration : AreaRegistration {
        public override string AreaName { get { return "Admin"; } }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Login", action = "Login", id = UrlParameter.Optional },
                new [] { "Web_CMS.Areas.Admin.Controllers" }
            );
        }
    }
}