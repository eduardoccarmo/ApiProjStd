﻿using Api.Proj.Std.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Interface
{
    public  interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllAsync();

        public Task<Product> GetById(int id);

        public Task<Product> PostAsync(Product product);

        public Task<Product> Put(Product product, int id);

    }
}
