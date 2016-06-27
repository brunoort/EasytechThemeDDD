using System.Web;
using System.Web.Optimization;

namespace AdminLteMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/AdminLTE/jquery-{version}.js",
                        "~/Scripts/AdminLTE/plugins/jQuery/jQuery-2.1.3.min.js"
                        ));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/AdminLTE/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                       "~/Scripts/AdminLTE/plugins/input-mask/jquery.inputmask.js",
                       "~/Scripts/AdminLTE/plugins/input-mask/jquery.inputmask.date.extensions.js",
                       "~/Scripts/AdminLTE/plugins/input-mask/jquery.inputmask.extensions.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/dialogjs").Include(
                       "~/Scripts/AdminLTE/bootstrap-dialog.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/growlNotify").Include(
                       "~/Scripts/AdminLTE/plugins/GrowlNotify/jquery.bootstrap-growl.js",
                        "~/Scripts/AdminLTE/plugins/GrowlNotify/jquery.bootstrap-growl.min.js"

                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/AdminLTE/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/AdminLTE/bootstrap.js",
                      "~/Scripts/AdminLTE/bootstrap.min.js",
                      "~/Scripts/AdminLTE/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                      "~/Scripts/AdminLTE/plugins/daterangepicker/daterangepicker-bs3.css",
                      "~/Scripts/AdminLTE/plugins/datepicker/datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/dialogcss").Include(
                     "~/Content/bootstrap-dialog.min.css"));
        }
    }
}
