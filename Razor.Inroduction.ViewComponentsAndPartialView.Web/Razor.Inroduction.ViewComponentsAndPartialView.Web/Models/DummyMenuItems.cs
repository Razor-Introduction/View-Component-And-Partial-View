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
            SetMenuItems("Man");
            SetMenuItems("Woman");
            SetMenuItems("Child");

        }

        private void SetMenuItems(string type)
        {

            for (int i = 1; i <= 10; i++)
            {
                var parent = new MenuItem
                {
                    Id = Guid.NewGuid(),
                    Name = $"Category {i}",
                    ParentId = Guid.Empty,
                    Type = type
                };

                MenuItems.Add(parent);

                for (int j = 1; j <= 3; j++)
                {
                    var child = new MenuItem
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Category {i}-{j}",
                        ParentId = parent.Id,
                        Type = type
                    };

                    MenuItems.Add(child);

                    for (int y = 1; y <= 2; y++)
                    {
                        var grandChild = new MenuItem
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Category {i}-{j}-{y}",
                            ParentId = child.Id,
                            Type = type
                        };

                        MenuItems.Add(grandChild);
                    }
                }
            }
        }

    }
}
