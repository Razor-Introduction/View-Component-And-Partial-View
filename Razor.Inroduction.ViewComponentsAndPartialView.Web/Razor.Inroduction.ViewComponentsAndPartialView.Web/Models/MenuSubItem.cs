using System;
using System.ComponentModel.DataAnnotations;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class MenuSubItem
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Href { get; set; }
        public Guid MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
