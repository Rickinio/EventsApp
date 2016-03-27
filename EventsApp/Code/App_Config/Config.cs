using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EventsApp.Code.App_Config
{
    public static class Config
    {
        static Config() {
            AdeleCookieName = ConfigurationManager.AppSettings["AdeleCookieName"];
            AdeleCookieValue = ConfigurationManager.AppSettings["AdeleCookieValue"];
            ViagogoClientId = ConfigurationManager.AppSettings["ViagogoClientId"];
            ViagogoClientSecretKey = ConfigurationManager.AppSettings["ViagogoClientSecretKey"];
            AntiforgeryCookieName = ConfigurationManager.AppSettings["AntiforgeryCookieName"];
        }

        public static string AdeleCookieName { get; set; }
        public static string AdeleCookieValue { get; set; }
        public static string ViagogoClientId { get; set; }
        public static string ViagogoClientSecretKey { get; set; }

        public static string AntiforgeryCookieName { get; set; }
    }
}
