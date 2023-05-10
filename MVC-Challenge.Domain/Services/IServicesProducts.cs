
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
        Task<IEnumerable<ProductsViewModel>> GetByDescriptionAsync(string description);
        Task<ProductsViewModel> GetById(int idProduct);
        Task<bool> Create(ProductCreateDto product);
        Task<bool> Update(ProductUpdateDto product);
        Task<bool> DeleteById(int idProduct);
    }
}
