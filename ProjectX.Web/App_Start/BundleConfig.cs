using System.Web;
using System.Web.Optimization;

namespace ProjectX.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //           "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Content/vendors/jquery/dist/jquery.js",
                        "~/Content/vendors/bootstrap/dist/js/bootstrap.js",
                        "~/Content/vendors/fastclick/lib/fastclick.js",
                        "~/Content/vendors/nprogress/nprogress.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                        "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/vendors/css/styles")
                        .Include("~/Content/vendors/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransform())
                        .Include("~/Content/vendors/nprogress/nprogress.css", 
                                 "~/Content/vendors/animate.css/animate.min.css")
                        .Include("~/Content/vendors/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/themes/css").Include("~/Content/themes/custom.css"));

            // KendoUI
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/2015.1.429/css").Include(
                //"~/Content/kendo/2015.1.429/kendo.common.min.css",
                        "~/Content/kendo/2015.1.429/kendo.common-bootstrap.min.css",
                //"~/Content/kendo/2015.1.429/kendo.bootstrap.min.css",
                //"~/Content/kendo/2015.1.429/kendo.blueopal.min.css",
                //"~/Content/kendo/2015.1.429/kendo.rtl.min.css",
                        "~/Content/kendo/2015.1.429/kendo.default.min.css",
                        "~/Content/kendo/2015.1.429/kendo.default.mobile.min.css",
                        "~/Content/kendo/2015.1.429/kendo.dataviz.min.css",
                        "~/Content/kendo/2015.1.429/kendo.dataviz.default.min.css",
                //"~/Content/kendo/2015.1.429/kendo.dataviz.blueopal.min.css",
                        "~/Content/kendo/2015.1.429/kendo.dataviz.bootstrap.min.css"));

            bundles.IgnoreList.Clear();

            //BundleTable.EnableOptimizations = true;
        }
    }
}