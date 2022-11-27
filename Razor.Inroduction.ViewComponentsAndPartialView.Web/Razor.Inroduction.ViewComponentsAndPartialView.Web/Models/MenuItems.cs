using System;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class MenuItems
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ParentId { get; set; }
    }
}
