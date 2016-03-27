using Autofac.Integration.Mvc;
using EventsApp.Code.App_Config;
using EventsApp.Services;
using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventsApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e) {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            AutoFacConfig.Init();

            //Harden Security
            SecurityConfig.HardenGlobalAsax();
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {
            HttpApplication app = (HttpApplication)sender;
            HttpContext appContext = app.Context;
            //Remove Server Header
            SecurityConfig.RemoveHeaders(appContext.Response);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception ex = Server.GetLastError().GetBaseException();

            LogService.Log(ex);

            //Clear Error and Redirect to Error page
            Server.ClearError();
            Response.Redirect("/Main/Error");
        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}