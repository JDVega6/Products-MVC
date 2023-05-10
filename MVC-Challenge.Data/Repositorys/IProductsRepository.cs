using MVC_Challenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Challenge.Data.Repositorys
{
    public interface IProductsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetProductsById(int id);
        public Task<IEnumerable<Products>> GetProductsByDescription(string descrption);
    }
}
