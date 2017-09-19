using System.Web;
using System.Web.Optimization;

namespace ClinicaMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/moment.js",
                "~/Scripts/transition.js",
                "~/Scripts/collapse.js",
                "~/Scripts/bootstrap.js",
                //"~/Scripts/bootstrap-modal.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/respond.js",
                "~/scripts/toastr.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.form.js",
                "~/scripts/app.js",
                "~/scripts/adminlte.js",
                "~/scripts/general.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/Ionicons/css/ionicons.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/skins/skin-green.css" )); //"~/Content/site.css"
                     
        }
    }
}
