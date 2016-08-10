using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                       "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                     "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/animatejs").Include(
                     "~/Scripts/animate-css.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/StyleSheet1.css"));
            bundles.Add(new ScriptBundle ("~/bundles/mixitup").Include(
                      "~/Scripts/jquery.mixitup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                     "~/Scripts/main.js"));
            bundles.Add(new StyleBundle("~/Content/animate").Include(
                     "~/Content/animate.css"));
            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                    "~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                      "~/Content/bootstrap.css"));


        }
    }
}
