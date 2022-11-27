﻿using Microsoft.EntityFrameworkCore;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Models
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Menu> MenuItems { get; set; }
    }
}
