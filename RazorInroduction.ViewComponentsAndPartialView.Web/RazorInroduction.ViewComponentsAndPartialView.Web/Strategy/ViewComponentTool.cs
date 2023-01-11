using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorInroduction.ViewComponentsAndPartialView.Web.Utils;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Constant;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Utils;
using System.Drawing.Drawing2D;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.Strategy;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Strategy
{
    public class ViewComponentTool : IComponentTool
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITempDataProvider _tempDataProvider;
        public string ComponentType { get; private set; }
        public ViewComponentTool(IServiceProvider serviceProvider, ITempDataProvider tempDataProvider)
        {
            _serviceProvider = serviceProvider;
            _tempDataProvider = tempDataProvider;
            ComponentType = Constants.ComponentType.ViewComponent;
        }
        public async Task<string> GetMenu(MenuModel menuModel)
        {
            return await RenderViewComponent("Menu", new { menuType = menuModel.Type });
        }
        public async Task<string> GetPopularProducts(PopularProductModel popularProductModel)
        {
            return await RenderViewComponent("PopularProducts", new { category = popularProductModel.Category, count = popularProductModel.Count });
        }
        public async Task<string> GetWomansDayContent(WomansDayModel womansDayModel)
        {
            return await RenderViewComponent("WomansDay", null);
        }
        public async Task<string> RenderViewComponent(string viewComponent, object args)
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };

            var sp = httpContext.RequestServices;

            var helper = new DefaultViewComponentHelper(
                sp.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
                HtmlEncoder.Default,
                sp.GetRequiredService<IViewComponentSelector>(),
                sp.GetRequiredService<IViewComponentInvokerFactory>(),
                sp.GetRequiredService<IViewBufferScope>());

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = args
            };

            using (var writer = new StringWriter())
            {
                var context = new ViewContext(actionContext, NullView.Instance, viewDictionary, new TempDataDictionary(actionContext.HttpContext, _tempDataProvider), writer, new HtmlHelperOptions());
                helper.Contextualize(context);
                var result = await helper.InvokeAsync(viewComponent, args);
                result.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
