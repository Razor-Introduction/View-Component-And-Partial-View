using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class Menu
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
