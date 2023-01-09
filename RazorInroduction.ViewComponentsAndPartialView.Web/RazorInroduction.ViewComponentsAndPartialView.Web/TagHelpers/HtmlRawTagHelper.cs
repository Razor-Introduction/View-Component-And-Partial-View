using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.TagHelpers
{

    public class HtmlRawTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var content = await output.GetChildContentAsync();
            var htmlDecoded = HttpUtility.HtmlDecode(content.GetContent());
            
            output.Content.SetHtmlContent(htmlDecoded);
        }
    }
}
