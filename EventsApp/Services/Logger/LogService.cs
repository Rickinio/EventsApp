using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EventsApp.Services
{
    public static class LogService
    {
        public static void Log(Exception ex) {
#if DEBUG
            Debug.WriteLine(JsonConvert.SerializeObject(ex));
#endif
        }
    }
}