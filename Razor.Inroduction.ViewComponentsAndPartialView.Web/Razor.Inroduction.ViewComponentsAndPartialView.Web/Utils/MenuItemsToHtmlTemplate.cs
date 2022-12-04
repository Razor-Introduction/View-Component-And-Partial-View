using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Utils
{
    public class MenuItemsToHtmlTemplate
    {
        public static List<MenuItem> MenuItems { private get; set; }
        public static string GetContent(string colorClass)
        {
            var parents = MenuItems.Where(mi => mi.ParentId == Guid.Empty).ToList();

            StringBuilder sb = new();

            sb.Append(@"<ul class=""navbar-nav"">");

            foreach (var item in parents)
            {
                sb.Append(@$"
                    <li class=""nav-item dropdown"">
                    <a class=""nav-link dropdown-toggle"" href=""#"" data-bs-toggle=""dropdown"">
                         {item.Name}
                    </a>"
                );

                var childs = MenuItems.Where(mi => mi.ParentId == item.ParentId).ToList();

                if (childs != null)
                {
                    sb.Append(@$"<ul class=""dropdown-menu"">");

                    var childContent = SetChildItems(childs);

                    sb.Append(childContent);

                    sb.Append("</ul>");
                }

                sb.Append("</li>");
            }

            sb.Append("</ul>");

            return NavbarProvider(sb.ToString(), colorClass);

        }

        private static string SetChildItems(List<MenuItem> childs)
        {
            var content = string.Empty;

            foreach (var child in childs)
            {
                content += $@"<li><a class=""dropdown-item"" href=""#""> {child.Name} </a>";

                if (MenuItems.Any(mi => mi.ParentId == child.Id))
                {
                    content += $@" <ul class=""submenu dropdown-menu"">";

                    content += SetChildItems(MenuItems.Where(mi => mi.ParentId == child.Id).ToList());

                    content += "</ul>";
                }

                content += "</li>";
            }
            return content;
        }

        public static string NavbarProvider(string content, string colorClass)
        {

            return $@"<nav class=""navbar navbar-expand-lg navbar-dark {colorClass}"">
                            <div class=""container-fluid"">
                                <a class=""navbar-brand"" href=""#"">Brand</a>
                                <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#main_nav"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                                </button>
                                <div class=""collapse navbar-collapse"" id=""main_nav"">
                                    {content}
                                </div>
                            </div>
                      </nav>";
        }

    }
}
