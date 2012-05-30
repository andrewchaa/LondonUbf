using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace LondonUbfWeb.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static string Image(this HtmlHelper helper, string imageName, string altText)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", 
                UrlHelpers.SiteRoot(helper.ViewContext.HttpContext) + "/content/images/" + imageName);
            builder.MergeAttribute("alt", altText);

            return builder.ToString(TagRenderMode.SelfClosing);
        }

        public static string Css(this HtmlHelper helper, string cssName)
        {
            var builder = new TagBuilder("link");
            builder.MergeAttribute("href", GetSiteRoot(helper) + "/content/css/" + cssName);
            builder.MergeAttribute("rel", "stylesheet");
            builder.MergeAttribute("type", "text/css");

            return builder.ToString(TagRenderMode.SelfClosing);
        }

        public static string Script(this HtmlHelper helper, string fileName)
        {
            var builder = new TagBuilder("script");
            builder.MergeAttribute("src", GetSiteRoot(helper) + "/content/scripts/" + fileName);
            builder.MergeAttribute("type", "text/javascript");

            return builder.ToString(TagRenderMode.Normal);
        }

        public static MvcHtmlString ClientIdFor<TModel, TProperty>(this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(
                    helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(
                        ExpressionHelper.GetExpressionText(expression)));
        }

        private static string GetSiteRoot(HtmlHelper helper)
        {
            return UrlHelpers.SiteRoot(helper.ViewContext.HttpContext);
        }
    }

}