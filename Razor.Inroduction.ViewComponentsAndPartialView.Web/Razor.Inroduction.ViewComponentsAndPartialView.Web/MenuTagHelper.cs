using Microsoft.AspNetCore.Razor.TagHelpers;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using System.Collections.Generic;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web
{
    public class MenuTagHelper : TagHelper
    {
        public List<MenuItems> MenuItems { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            MenuItemsToHtmlTemplate.MenuItems = MenuItems;

            output.Content.SetHtmlContent(MenuItemsToHtmlTemplate.GetContent());
        }

    }
}
