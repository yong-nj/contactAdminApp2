using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace ContactAdminApp2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog logger = LogManager.GetLogger("SystemLog");
        //protected static string mainLogfile = "/yonglogs/EventLog_main.txt";
        //protected static string f = HttpRuntime.AppDomainAppPath + mainLogfile;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            logger.Info("log4net: Application started!");
        }

        protected void Application_End()
        {
            logger.Info("log4net: Application ended!");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            logger.Info("Application error: " + exception.ToString());
        }
    }
}
