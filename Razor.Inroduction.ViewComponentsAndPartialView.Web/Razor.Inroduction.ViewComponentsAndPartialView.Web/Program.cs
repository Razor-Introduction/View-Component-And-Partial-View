using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseInMemoryDatabase("MenuItemsInMemoryDatabase");
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

    DummyMenu dummyData = new();

    db.MenuCategories.AddRange(dummyData.MenuCategories);
    db.MenuItems.AddRange(dummyData.MenuItems);
    db.MenuSubItems.AddRange(dummyData.MenuSubItems);

    db.SaveChanges();
}
