using WS.MVC.Models;
using WS.MVC.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace WS.MVC.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<ProductModel> Products => Set<ProductModel>();
        public DbSet<CategoryModel> Categories => Set<CategoryModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
        }
    }
}