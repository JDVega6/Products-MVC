
using MVC_Challenge.Data.Models;
using MVC_Challenge.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Challenge.Domain.Services
{
    public interface IServicesProducts
    {
        Task<IEnumerable<ProductsViewModel>> GetProductsAsync();
        //Task<List<Products>> GetProducts();
        //Task<bool> Save(Products product);
    }
}
