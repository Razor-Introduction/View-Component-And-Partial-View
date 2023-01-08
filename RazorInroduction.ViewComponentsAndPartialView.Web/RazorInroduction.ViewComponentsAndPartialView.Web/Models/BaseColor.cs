using System;
using System.ComponentModel.DataAnnotations;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models
{
    public class BaseColor
    {
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
    }
}
