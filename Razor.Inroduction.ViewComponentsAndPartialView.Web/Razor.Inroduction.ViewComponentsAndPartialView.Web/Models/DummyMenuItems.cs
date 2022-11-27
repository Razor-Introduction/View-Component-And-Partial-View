using System;
using System.Collections.Generic;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class DummyMenuItems
    {
        public List<MenuItem> MenuItems { get; set; }
        public DummyMenuItems()
        {
            MenuItems = new();

            for (int i = 1; i <= 10; i++)
            {
                var parent = new MenuItem
                {
                    Id = Guid.NewGuid(),
                    Name = $"Category {i}",
                    ParentId = Guid.Empty
                };

                MenuItems.Add(parent);

                for (int j = 1; j <= 5; j++)
                {
                    var child = new MenuItem
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Category {i}-{j}",
                        ParentId = parent.Id
                    };

                    MenuItems.Add(child);

                    for (int y = 1; y <= 10; y++)
                    {
                        var grandChild = new MenuItem
                        {
                            Id = Guid.NewGuid(),
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
