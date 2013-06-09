using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using BundleTransformer.Core;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;


namespace TodoMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            var nullBuilder = new NullBuilder();
            var cssTransformer = new CssTransformer();
            var jsTransformer = new JsTransformer();
            var nullOrderer = new NullOrderer();

            /*Common Styles */
            var commonStylesBundle = new Bundle("~/Bundles/CommonStyles");
            commonStylesBundle.Include("~/Content/bootstrap.css");
            commonStylesBundle.Builder = nullBuilder;
            commonStylesBundle.Transforms.Add(cssTransformer);
            commonStylesBundle.Orderer = nullOrderer;

            bundles.Add(commonStylesBundle);

            /*App Css */
            var appStylesBundle = new Bundle("~/Bundles/AppStyles");
            appStylesBundle.Include(
                "~/App/css/base.css",
                "~/App/css/custom.css");
            appStylesBundle.Builder = nullBuilder;
            appStylesBundle.Transforms.Add(cssTransformer);
            appStylesBundle.Orderer = nullOrderer;

            bundles.Add(appStylesBundle);

        }
    }
}