using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web
{
    public class MenuItemsToHtmlTemplate
    {
        public static List<MenuItem> MenuItems { private get; set; }
        public static string GetContent()
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

            return sb.ToString();

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

                    content += SetChildItems(MenuItems.Where(mi=>mi.ParentId == child.Id).ToList());

                    content += "</ul>";
                }

                content += "</li>";
            }
            return content;
        }

    }
}
