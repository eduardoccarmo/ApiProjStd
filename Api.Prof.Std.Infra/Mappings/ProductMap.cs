using Api.Proj.Std.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Prof.Std.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT");

            builder.HasAlternateKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID_PRODUCT")
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn()
                .HasColumnType("NUMBER");

            builder.Property(x => x.Name)
                .HasColumnName("PRODUCT_NAME")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(x => x.Brand)
                .HasColumnName("PRODUCT_BRAND")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Price)
                .HasColumnName("PRODUCT_PRICE")
                .HasColumnType("DECIMAL")
                .HasPrecision(2);

            builder.Property(x => x.RegisterDate)
                .HasColumnName("DATE_REGISTER")
                .HasColumnType("DATETIME");

            builder.Property(x => x.LastUpdateDate)
                .HasColumnName("CHANGE_DATE")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Category)
                .HasColumnName("ID_CATEGORY")
                .HasColumnType("INT");
        }
    }
}
