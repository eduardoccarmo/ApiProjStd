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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR2")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("SURNAME")
                .HasColumnType("VARCHAR2")
                .IsRequired();

            builder.Property(x => x.NickName)
                .HasColumnName("USER_NICKNAME")
                .HasColumnType("VARCHAR2");

            builder.Property(x => x.Email)
                .HasColumnName("USER_EMAIL")
                .HasColumnType("VARCHAR2");

            builder.Property(x => x.Phone)
                .HasColumnName("USER_PHONE")
                .HasColumnType("VARCHAR2");

            builder.Property(x => x.Gender)
                .HasColumnName("USER_GENDER")
                .HasColumnType("CHAR");
        }
    }
}
