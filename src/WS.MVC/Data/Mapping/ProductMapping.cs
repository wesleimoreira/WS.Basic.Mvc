using WS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WS.MVC.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductQuantity).HasColumnType("INT").IsRequired();
            builder.Property(x => x.ProductName).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.ProductPrice).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(x => x.IsProductActive).HasColumnType("TINYINT").IsFixedLength(true);
        }
    }
}