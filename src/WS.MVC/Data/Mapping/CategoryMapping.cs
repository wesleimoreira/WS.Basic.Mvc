using WS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WS.MVC.Data.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName).HasColumnType("VARCHAR(50)").IsRequired();

            builder
            .HasMany(x => x.GetProductModels)
            .WithOne(x => x.GetCategoryModel)
            .HasForeignKey(x => x.CategoryId)
            .HasPrincipalKey(x => x.CategoryId);
        }
    }
}