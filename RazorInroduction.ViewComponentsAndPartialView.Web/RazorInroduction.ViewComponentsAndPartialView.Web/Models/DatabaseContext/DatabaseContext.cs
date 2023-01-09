using Microsoft.EntityFrameworkCore;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Menu> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuSubItem> MenuSubItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BaseColor> BaseColors { get; set; }

    }
}
