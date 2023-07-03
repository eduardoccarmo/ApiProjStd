﻿using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Prof.Std.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Api.Prof.Std.Infra.Context;
using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Application.Services;

namespace Api.Proj.Std.IoC
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
