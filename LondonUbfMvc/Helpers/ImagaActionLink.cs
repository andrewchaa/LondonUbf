using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;

namespace LondonUbfWeb.Helpers
{
    public static class ImagaActionLink
    {
        public static string ImageActionLink(this HtmlHelper helper, string imageUrl, string altText, string actionName, 
            object routeValues)
        {
            return BuildImageActionLink(helper, imageUrl, altText, actionName, routeValues, null);
        }

        public static string ImageActionLink(this HtmlHelper helper, string imageUrl, string altText, string actionName, 
            object routeValues, object htmlAttriutes)
        {
            return BuildImageActionLink(helper, imageUrl, altText, actionName, routeValues, htmlAttriutes);
        }

        private static string BuildImageActionLink(HtmlHelper helper, string imageUrl, string altText, string actionName, object routeValues, object htmlAttriutes)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);

            var link = helper.ActionLink("[placeholder]", actionName, routeValues, htmlAttriutes);

            return link.ToString().Replace("[placeholder]", builder.ToString(TagRenderMode.SelfClosing));
        }

        public static string ImageActionLink(this AjaxHelper helper, string imageUrl, string altText, string actionName, 
            object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);

            var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions);
            return link.ToString().Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing));
        }

    }
}
