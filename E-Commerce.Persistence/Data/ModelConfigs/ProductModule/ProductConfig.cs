using E_Commerce.Domain.Models.ProductModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Data.ModelConfigs.ProductModule
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name)
                   .HasColumnType("nvarchar") //default 
                   .HasMaxLength(100);

            builder.Property(P => P.Description)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(500);

            builder.Property(propertyExpression: P => P.PictureUrl)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(200);

            builder.Property(propertyExpression: P => P.Price)
                   .HasPrecision(18,2);

            builder.HasOne(P => P.Brand)
                   .WithMany()
                   .HasForeignKey(P => P.BrandId);

            builder.HasOne(P => P.Type)
                   .WithMany()
                   .HasForeignKey(P => P.TypeId);

        }
    }

}
