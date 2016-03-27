using EventsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EventsApp.Code.App_Config
{
    public static class SecurityConfig
    {
        /// <summary>
        /// Use in App start to configure web app
        /// </summary>
        public static void HardenGlobalAsax() {
            MvcHandler.DisableMvcResponseHeader = true;
            AntiForgeryConfig.CookieName = Config.AntiforgeryCookieName;
        }

        /// <summary>
        /// Remove server headers from response
        /// </summary>
        /// <param name="response"></param>
        public static void RemoveHeaders(HttpResponse response) {
            if (response != null) {
                response.AddOnSendingHeaders((context) => {
                    try {
                        if (context != null && context.Response != null && !context.Response.HeadersWritten) {
                            context.Response.Headers.Remove("Server");
                        }
                    }
                    catch (Exception ex) {
                        LogService.Log(ex);
                    }
                });
            }
        }
    }
}