using System;
using System.Collections.Generic;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Utils
{
    public class DummyMenu
    {
        public List<Menu> MenuCategories { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<MenuSubItem> MenuSubItems { get; set; }

        public DummyMenu()
        {
            MenuCategories = new();
            MenuItems = new();
            MenuSubItems = new();

            SetMenuItems("Man");
            SetMenuItems("Woman");
            SetMenuItems("Child");

        }

        private void SetMenuItems(string type)
        {
            Menu menuCategory = new() { Id = Guid.NewGuid(), Type = type };
            MenuCategories.Add(menuCategory);

            for (int i = 1; i <= 9; i++)
            {
                var parent = new MenuItem
                {
                    Id = Guid.NewGuid(),
                    Name = $"{type[..1].ToLower()}.Category {i}",
                    MenuCategoryId = menuCategory.Id,

                };

                MenuItems.Add(parent);

                for (int j = 1; j <= 10; j++)
                {
                    var child = new MenuSubItem
                    {
                        Id = Guid.NewGuid(),
                        Name = $"{type[..1].ToLower()}.Category {i}-{j}",
                        Href = $"Product/Category{i}-{j}.cshtml",
                        MenuItemId = parent.Id
                    };

                    MenuSubItems.Add(child);

                }
            }
        }

    }
}
