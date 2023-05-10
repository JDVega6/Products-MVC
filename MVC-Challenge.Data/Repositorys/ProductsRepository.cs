using Microsoft.EntityFrameworkCore;
using MVC_Challenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Challenge.Data.Repositorys
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductContextDb _context;
        public ProductsRepository(ProductContextDb context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            var product = await _context.Product.ToListAsync();
            return product;
        }

        public async Task<IEnumerable<Products>> GetProductsByDescription(string description)
        {
            var products = await _context.Product.ToListAsync();
            if (description != null)
            {
                products = products.Where(x => x.Description.ToLower().Contains(description)).ToList();
            }

            return products;
        }

        public async Task<Products> GetProductsById(int id)
        {
            var product = await _context.Product.FirstOrDefaultAsync( u => u.Id == id);
            return product;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
