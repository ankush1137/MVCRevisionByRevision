using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewDemo.common
{
    public static class CustomHtmlHelper
    {
        public static IHtmlContent Button(this IHtmlHelper hepler,
            string type,string value, string? classes)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.Attributes["type"]=type;
            builder.Attributes["value"]=value;
            builder.AddCssClass(classes);

            return builder;

        }
    }
}
