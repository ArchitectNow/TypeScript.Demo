using System;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace TypeScript.Demo
{
    public class BundleConfig
    {
        public static string AdminAppDir = "app";

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            AddAngularBundles(bundles);

            AddAppBundles(bundles);
            bundles.IgnoreList.Ignore("*Spec.js");
        }

        private static void AddAngularBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/angularscripts").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-sanitize.js",
           
                      "~/Scripts/angular-route.js"));
        }

        private static void AddAppBundles(BundleCollection bundles)
        {
            var scriptBundle = new ScriptBundle("~/adminscripts");
            var adminAppDirFullPath = HttpContext.Current.Server.MapPath(string.Format("~/{0}", AdminAppDir));
            if (Directory.Exists(adminAppDirFullPath))
            {
                scriptBundle.Include(
                    // Order matters, so get the core app setup first
                    string.Format("~/{0}/app.module.js", AdminAppDir),
                    string.Format("~/{0}/app.core.module.js", AdminAppDir))
                    // then get any other top level js files
                    .IncludeDirectory(string.Format("~/{0}", AdminAppDir), "*.js", false)
                    // then get all nested module js files
                    .IncludeDirectory(string.Format("~/{0}", AdminAppDir), "*.module.js", true)
                    // finally, get all the other js files
                    .IncludeDirectory(string.Format("~/{0}", AdminAppDir), "*.js", true);
            }
            bundles.Add(scriptBundle);
            bundles.Add(new StyleBundle("~/adminstyles").Include(
                "~/content/css/admin.css"));
        }
    }
}
