using Microsoft.AspNetCore.Razor.TagHelpers;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.TagHelpers
{
    public class MenuTagHelper : TagHelper
    {
        public List<MenuItem> MenuItems { get; set; }
        public string Color { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            MenuItemsToHtmlTemplate.MenuItems = MenuItems;

            output.Content.SetHtmlContent(MenuItemsToHtmlTemplate.GetContent(Color));
        }

    }
}
