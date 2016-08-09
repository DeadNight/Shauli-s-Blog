using System.Web;
using System.Web.Optimization;

namespace Exercise_2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/style/base.css",
                "~/Content/style/navigation.css",
                "~/Content/style/introduction.css",
                "~/Content/style/filter.css",
                "~/Content/style/content-and-sidebar.css",
                "~/Content/style/footer.css"
            ));
        }
    }
}
