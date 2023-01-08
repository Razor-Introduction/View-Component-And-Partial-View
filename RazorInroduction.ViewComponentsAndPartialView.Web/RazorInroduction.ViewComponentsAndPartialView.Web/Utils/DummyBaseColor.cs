using RazorInroduction.ViewComponentsAndPartialView.Web.Models;
using System;
using System.Collections.Generic;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Utils
{
    public class DummyBaseColor
    {
        public List<BaseColor> BaseColors { get; set; }

        public DummyBaseColor()
        {
            BaseColors = new();
            SetBaseColors();
        }
        public void SetBaseColors()
        {
            List<BaseColor> baseColors = new()
            {
                new BaseColor()
                {
                    Id = Guid.NewGuid(),
                    Category = "Man",
                    Primary ="primary",
                    Secondary ="#cce5ff"
                },
                new BaseColor()
                {
                    Id = Guid.NewGuid(),
                    Category="Woman",
                    Primary="danger",
                    Secondary ="#f8d7da"
                },
                new BaseColor()
                {
                    Id = Guid.NewGuid(),
                    Category ="Child",
                    Primary ="success",
                    Secondary ="#d4edda"
                }
            };
            BaseColors.AddRange(baseColors);
        }
    }

}
