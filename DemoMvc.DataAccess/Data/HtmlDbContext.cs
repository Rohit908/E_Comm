using DemoMVC.Models.Html;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DataAccess.Data
{
    public class HtmlDbContext:DbContext
    {
        public HtmlDbContext(DbContextOptions<HtmlDbContext> options):base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Sequence=1, CSS_Class="", Title="Home", Icon="", URL="/", ParentId = 0},
                new Menu { Id = 2, Sequence = 2, CSS_Class = "", Title = "Content Management", Icon = "", URL = "/", ParentId = 0 },
                new Menu { Id = 3, Sequence = 1, CSS_Class = "", Title = "Category", Icon = "", URL = "/", ParentId = 2 },
                new Menu { Id = 4, Sequence = 2, CSS_Class = "", Title = "Cover Type", Icon = "", URL = "/", ParentId = 2 },
                new Menu { Id = 5, Sequence = 3, CSS_Class = "", Title = "Product", Icon = "", URL = "/", ParentId = 2 }
            );
        }
    }
}
