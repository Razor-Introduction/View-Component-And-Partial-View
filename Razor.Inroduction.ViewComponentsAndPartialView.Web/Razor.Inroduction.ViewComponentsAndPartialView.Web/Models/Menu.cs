using System;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid ParentId { get; set; }
    }
}
