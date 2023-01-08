using System;
using System.ComponentModel.DataAnnotations;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }
}
