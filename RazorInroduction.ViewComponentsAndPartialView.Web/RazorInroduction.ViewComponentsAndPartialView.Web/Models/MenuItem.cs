using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models
{
    public class MenuItem
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MenuCategoryId { get; set; }
        public Menu MenuCategory { get; set; }
        public virtual List<MenuSubItem> MenuSubItems { get; set; }
    }
}
