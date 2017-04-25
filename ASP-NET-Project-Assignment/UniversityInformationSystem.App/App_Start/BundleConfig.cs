using System.Web;
using System.Web.Optimization;

namespace UniversityInformationSystem.App
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        { 

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.js",
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Ajax validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Kendo styles and scripts
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/Kendo/kendo.all.min.js", 
                        "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo-css").Include(
                        "~/Content/Kendo/kendo.common.min.css",
                        "~/Content/Kendo/kendo.default.min.css"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/sidebar").Include(
                      "~/Scripts/sidebar.js"));

            bundles.Add(new ScriptBundle("~/bundles/error-handler").Include(
                "~/Scripts/error-handler.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/united.bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/login-form.css",
                      "~/Content/sidebar.css"));

        }
    }
}
