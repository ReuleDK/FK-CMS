using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;

namespace Web_CMS
{
    public class MvcApplication : HttpApplication
    {
        ILog log = LogManager.GetLogger(typeof(MvcApplication));

        public override void Init()
        {
            base.Init();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new ExecuteCustomErrorHandler());
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = this.Server.GetLastError();
            log.Error("Unhandled exception logged in Application." + Environment.NewLine +
                "User : " + "TODO" + Environment.NewLine +
                "Page : " + HttpContext.Current.Request.Url.AbsoluteUri, exception);
        }
    }
}
