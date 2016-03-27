using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EventsApp.Code.App_Config
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) {

            bundles.Add(new StyleBundle("~/content/styles").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css")
            );

            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-ui-router.js",
                        "~/Scripts/Infinite-scroll.js"
                         )
                      );

            Bundle jsBundle = new ScriptBundle("~/bundles/app")
                .IncludeDirectory("~/App/", "*.js")
                .IncludeDirectory("~/App/Services/", "*.js", true)
                .IncludeDirectory("~/App/Directives/", "*.js", true)
                .IncludeDirectory("~/App/Features/", "*.js", true)
                ;

            bundles.Add(jsBundle);

            BundleTable.EnableOptimizations = false;

        }

    }
}