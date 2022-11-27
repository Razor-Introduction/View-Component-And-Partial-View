using System;
using System.Collections.Generic;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class DummyMenuItems
    {
        public List<Menu> MenuItems { get; set; }
        public DummyMenuItems()
        {
            MenuItems = new();

            for (int i = 0; i < 10; i++)
            {
                var parent = new Menu
                {
                    Id = new Guid(),
                    Name = $"Category {i}",
                    ParentId = Guid.Empty
                };

                MenuItems.Add(parent);

                for (int j = 0; j < 5; j++)
                {
                    var child = new Menu
                    {
                        Id = new Guid(),
                        Name = $"Category {i}-{j}",
                        ParentId = parent.Id
                    };

                    MenuItems.Add(child);

                    for (int y = 0; y < 5; y++)
                    {
                        var grandChild = new Menu
                        {
                            Id = new Guid(),
                            Name = $"Category {i}-{j}-{y}",
                            ParentId = child.Id
                        };

                        MenuItems.Add(grandChild);
                    }
                }
            }

        }

    }
}
