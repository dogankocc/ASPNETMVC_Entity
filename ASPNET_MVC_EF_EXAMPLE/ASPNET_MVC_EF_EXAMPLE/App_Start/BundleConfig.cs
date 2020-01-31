using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ASPNET_MVC_EF_EXAMPLE.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                 "~/Scripts/custom.js",
                 "~/Content/js/bootstrap.bundle.js",
                 "~/Content/js/bootstrap.bundle.js.map",
                 "~/Content/js/bootstrap.bundle.min.js",
                 "~/Content/js/bootstrap.bundle.min.js.map",
                 "~/Content/js/bootstrap.js",
                 "~/Content/js/bootstrap.js.map",
                 "~/Content/js/bootstrap.min.js",
                 "~/Content/js/bootstrap.min.js.map",
                 "~/Content/js/jquery.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/css/bootstrap.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/css/account").Include(
                "~/Content/account/account-style.css",
                "~/Content/css/bootstrap.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/css/layout").Include(
                 "~/Content/layout/layout-style.css",
                 "~/Content/css/bootstrap.min.css"
            ));
        }
    }
}