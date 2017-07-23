using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
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
                "~/Content/Site.css",
                "~/Content/bootstrap.css",
                "~/Content/ui-bootstrap-csp.css",
                "~/Content/toaster.css",
                "~/Content/ui-grid.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/jquery-*",
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-loader.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/i18n/angular-locale_ru-ru.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-messages.js",
                "~/Scripts/angular-touch.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-ui.js",
                "~/Scripts/toaster.js",
                "~/Scripts/ui-grid.js"
                ));

            const string ANGULAR_APP_ROOT = "~/Angular/";
            const string VIRTUAL_BUNDLE_PATH = ANGULAR_APP_ROOT + "main.js";

            var scriptBundle = new ScriptBundle(VIRTUAL_BUNDLE_PATH)
                .Include(ANGULAR_APP_ROOT + "app.js")
                .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", searchSubdirectories: true);

            bundles.Add(scriptBundle);

            BundleTable.EnableOptimizations = false;
        }
    }
}
