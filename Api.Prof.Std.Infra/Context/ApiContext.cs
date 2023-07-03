using Api.Prof.Std.Infra.Mappings;
using Api.Proj.Std.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Api.Prof.Std.Infra.Context
{
    public class ApiContext : DbContext
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Profile> Profiles { get; set; }

        private string _connectionString = "Server=localhost;Port=3306;Database=project_std;Uid=root;Pwd=root;";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));
        }
    }
}
