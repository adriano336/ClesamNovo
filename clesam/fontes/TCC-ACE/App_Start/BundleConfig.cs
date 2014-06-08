using System.Web;
using System.Web.Optimization;

namespace TCC_ACE
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ace-extra").Include(
                        "~/Scripts/ace/ace-extra.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

     

            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                        "~/Scripts/ace/bootstrap.min.js",
                        "~/Scripts/ace/typeahead-bs2.min.js",
                        "~/Scripts/ace/jquery-ui-1.10.3.custom.min.js",
                        "~/Scripts/ace/jquery.ui.touch-punch.min.js",
                        "~/Scripts/ace/jquery.slimscroll.min.js",
                        "~/Scripts/ace/ace-elements.min.js",
                        "~/Scripts/ace/ace.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                        "~/Scripts/ace/jquery.dataTables.min.js",
                        "~/Scripts/ace/jquery.dataTables.bootstrap.js"
                 ));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/ace/css/bootstrap.min.css",
                      "~/Content/ace/css/ace.min.css",
                      "~/Content/ace/css/font-awesome.min.css",
                      "~/Content/ace/css/jquery-ui-1.10.3.custom.min.css",
                      "~/Content/ace/css/ace-fonts.css",
                      "~/Content/ace/css/ace-rtl.min.css",
                      "~/Content/ace/css/ace-skins.min.css",
                      "~/Content/Site.css"
                      ));
        }
    }
}
