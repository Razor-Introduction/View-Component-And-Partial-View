using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.TagHelpers
{
    [HtmlTargetElement("currency", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CurrencyTagHelper : TagHelper
    {
        [HtmlAttributeName("ref")]
        public string? Reference { get; set; }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            if (string.IsNullOrEmpty(Reference))
            {
                return;
            }

            var content = (await output.GetChildContentAsync()).GetContent();

            var currencySymbol = Reference switch
            {
                "tr" => "₺",
                "en" => "$",
                _ => "€",
            };

            output.Content.SetContent($"{content} {currencySymbol}"); 

        }
    }
}
