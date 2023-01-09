using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Constant;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Strategy;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseInMemoryDatabase("MenuItemsInMemoryDatabase");
});
builder.Services.AddScoped<IComponentTool>(sp =>
{
    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
    var menuToolType = httpContextAccessor?.HttpContext?.Request.Cookies[Constants.CookieName];

    var razorViewEngine = sp.GetRequiredService<IRazorViewEngine>();
    var tempDataProvider = sp.GetRequiredService<ITempDataProvider>();

    if (string.IsNullOrEmpty(menuToolType))
    {
        return new PartialViewTool(razorViewEngine, tempDataProvider, sp);
    }

    return menuToolType switch
    {
        Constants.ComponentType.PartialView => new PartialViewTool(razorViewEngine, tempDataProvider, sp),
        Constants.ComponentType.ViewComponent => new ViewComponentTool(sp, tempDataProvider),
        _ => throw new System.NotImplementedException()
    };

});
var app = builder.Build();

SetDummyData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static void SetDummyData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<DatabaseContext>();

    DummyMenu dummyMenus = new();
    DummyProduct dummyProducts = new();
    DummyBaseColor dummyBaseColors = new();

    db.MenuCategories.AddRange(dummyMenus.MenuCategories);
    db.MenuItems.AddRange(dummyMenus.MenuItems);
    db.MenuSubItems.AddRange(dummyMenus.MenuSubItems);
    db.Products.AddRange(dummyProducts.Products);
    db.BaseColors.AddRange(dummyBaseColors.BaseColors);
    db.SaveChanges();
}
