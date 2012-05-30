using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LondonUbfWeb.Helpers
{
    public class DownloadResult : ActionResult
    {
        private string _name, _encodedName, _fullname, _root;

        public DownloadResult() { }
        public DownloadResult(string root, string name, string partialPath)
        {
            _root = root;
            _name = name;
            _fullname = Path.Combine(_root, partialPath);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpBrowserCapabilitiesBase browser = context.HttpContext.Request.Browser;

            if (string.Compare(browser.Browser, "IE", true) == 0)
                _encodedName = HttpUtility.UrlEncode(_name).Replace("+", "%20");
            else
                _encodedName = _name;

            context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=\"" + _encodedName + "\"");
            context.HttpContext.Response.TransmitFile(_fullname);
        }
    }
}
