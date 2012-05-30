using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace LondonUbfWeb.Helpers
{
    public static class AppHelper
    {
        public static string SiteAbsolutePath { get; set; }
        public static string TemplateAbsolutePath { get; set; }

        public static string ContentRoot
        {
            get
            {
                return VirtualPathUtility.ToAbsolute("~/Content");
            }
        }

        public static string CssRoot
        {
            get
            {
                return string.Format("{0}/{1}", ContentRoot, "css");
            }
        }

        public static string ImageUrl(string file)
        {
            return string.Format("{0}/{1}/{2}", ContentRoot, "images", file);
        }

        public static string CssUrl(string file)
        {
            return string.Format("{0}/{1}/{2}", ContentRoot, "css", file);
        }

        public static string ScriptUrl(string file)
        {
            return string.Format("{0}/{1}/{2}", ContentRoot, "scripts", file);
        }

        public static string UploadifyUrl(string file)
        {
            return string.Format("{0}/{1}/{2}", ContentRoot, "uploadify", file);
        }

        public static SelectList ToSelectList(this IEnumerable list, string value)
        {
            return new SelectList(list, value);
        }

        public static SelectList ToSelectList(this IEnumerable list, string dataValueField, string dataTextField)
        {
            return new SelectList(list, dataValueField, dataTextField);
        }
    }
}
