using Microsoft.EntityFrameworkCore;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Menu> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuSubItem> MenuSubItems { get; set; }
    }
}
