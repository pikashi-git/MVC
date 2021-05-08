using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;

namespace MVC網站.Helpers
{
    public static class ImageHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            var innertext = @"<script>alert('test');</script>";
            return MvcHtmlString.Create(string.Format(@"<img src=""{0}"" alt=""{1}"">{2}</img>", AntiXssEncoder.XmlAttributeEncode(src), AntiXssEncoder.XmlAttributeEncode(alt), AntiXssEncoder.HtmlEncode(innertext,true)));
        }
        public static MvcHtmlString Image(this HtmlHelper helper, string id, string src, string alt)
        {
            var innertext = @"<script>alert('test');</script>";
            var tag = new TagBuilder("img");
            tag.GenerateId(id);
            var data = new Dictionary<string, string>() { { "src", src }, { "alt", alt }, { "title", "測試tagbuilder"} };
            tag.MergeAttributes(data, true);
            tag.AddCssClass("test");
            tag.SetInnerText(innertext);
            //tag.InnerHtml = innertext;
            //tag.InnerHtml = AntiXssEncoder.HtmlEncode(innertext, true);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}