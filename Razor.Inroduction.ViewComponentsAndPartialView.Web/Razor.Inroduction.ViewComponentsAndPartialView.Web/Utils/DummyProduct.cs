using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using System;
using System.Collections.Generic;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Utils
{
    public class DummyProduct
    {
        public List<Product> Products { get; set; }

        public DummyProduct()
        {
            Products = new();
            SetProducts("Man");
            SetProducts("Woman");
            SetProducts("Child");
        }

        public void SetProducts(string type)
        {
            Random random = new();

            for (int i = 1; i <= 8; i++)
            {
                Product product = new()
                {
                    Id = Guid.NewGuid(),
                    Category = type,
                    Image = "/images/image.png",
                    Name = $"{type}-{i} Product",
                    Price = Math.Round(random.NextDouble() * (5000 - 1000) + 1000, 2)
                };

                Products.Add(product);
            }
        }
    }
}
