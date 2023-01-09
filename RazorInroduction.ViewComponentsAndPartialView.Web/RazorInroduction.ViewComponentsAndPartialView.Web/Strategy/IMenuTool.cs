using Microsoft.AspNetCore.Mvc;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using System.Threading.Tasks;
using static Razor.Inroduction.ViewComponentsAndPartialView.Web.Constant.MenuConstants;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Strategy
{
    public interface IMenuTool
    {
        public string ComponentType { get;}
        public Task<string> Get(MenuViewModel menuViewModel);
    }
}
