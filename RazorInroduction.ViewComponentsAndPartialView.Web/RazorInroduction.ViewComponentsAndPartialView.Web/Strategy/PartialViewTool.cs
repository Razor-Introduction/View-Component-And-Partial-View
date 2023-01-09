using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Constant;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.Strategy;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using static Razor.Inroduction.ViewComponentsAndPartialView.Web.Constant.Constants;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Strategy
{
    public class PartialViewTool : IComponentTool
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        public string ComponentType { get; private set; }


        public PartialViewTool(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            ComponentType = Constants.ComponentType.PartialView;
        }

        public async Task<string> GetMenu(MenuModel menuModel)
        {
            return await RenderToStringAsync("_Menu", menuModel.menuViewModel);
        }
        public async Task<string> GetPopularProducts(PopularProductModel popularProductModel)
        {
            return await RenderToStringAsync("_PopularProducts", popularProductModel.PopularProductViewModel);
        }
        public async Task<string> GetWomansDayContent(WomansDayModel womansDayModel)
        {
            return await RenderToStringAsync("_PopularProducts", womansDayModel.WomansDayViewModel);
        }
        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }
    }
}
