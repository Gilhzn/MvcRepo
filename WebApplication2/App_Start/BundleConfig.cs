using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication2.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery")
                 .Include("~/Scripts/jquery-1.12.4.js")
                 .Include("~/Scripts/jquery-ui-1.12.1.min.js"));
        }
    }
}