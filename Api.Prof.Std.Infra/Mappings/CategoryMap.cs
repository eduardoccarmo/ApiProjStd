﻿using Api.Proj.Std.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Prof.Std.Infra.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORY");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID_CATEGORY")
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("CATEGORY_NAME")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.RegisterDate)
                .IsRequired()
                .HasColumnName("DATE_REGISTER")
                .HasColumnType("DATETIME");

            //builder.HasMany(x => x.Products)
            //    .WithOne(x => x.Category)
            //    .HasForeignKey(x => x.Category);

        }
    }
}
