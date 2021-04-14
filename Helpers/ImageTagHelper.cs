using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCollege.Helpers
{
    public static class ImageTagHelper
    {

        public static IHtmlString Img(string src, string alt,string @class, string style)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}' class='{2}' style='{3}' >", src,alt, @class, style));
        }

        public static IHtmlString Image(this HtmlHelper htmlHelper, string src, string alt, string @class, string style)
        {
            TagBuilder tag = new TagBuilder("img");
            tag.Attributes.Add("src", src);
            tag.Attributes.Add("alt", alt);
            tag.Attributes.Add("class", @class);
            tag.Attributes.Add("style", style);
            return new MvcHtmlString(tag.ToString());
            //return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}' class='{2}' style='{3}' >", src, alt, @class, style));
        }

    }
}