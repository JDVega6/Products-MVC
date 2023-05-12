using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVC_Challenge.Data.Models;
using MVC_Challenge.Data.Repositorys;
using MVC_Challenge.Domain.Dtos;
using Newtonsoft.Json;

namespace MVC_Challenge.Domain.Services
{
    public class ServicesProducts : IServicesProducts
    {

        private readonly IProductsRepository _repo;
        private readonly IMapper _mapper;

        public ServicesProducts(IProductsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetProductsAsync()
        {
            var products = await _repo.GetProductsAsync();
            var productoView = _mapper.Map<IEnumerable<ProductsViewModel>>(products);
            return productoView;
        }

        public async Task<IEnumerable<ProductsViewModel>> GetByDescriptionAsync(string description)
        {
                description = description.ToLower();
                var productsList = await _repo.GetProductsByDescription(description);
                return _mapper.Map<IEnumerable<ProductsViewModel>>(productsList);
        }

        public async Task<bool> Create(ProductCreateDto product)
        {
             var productoToCreate = _mapper.Map<Products>(product);
            _repo.Add(productoToCreate);
            return await _repo.SaveAll();
        }
        public async Task<bool> Update(ProductUpdateDto productUpdate)
        {
            var product = _mapper.Map<Products>(productUpdate);
            _repo.Update(product);
            return await _repo.SaveAll();
        }

        public async Task<bool> DeleteById(int idProduct)
        {
            var product = await _repo.GetProductsById(idProduct);
            _repo.Delete(product);
            return await _repo.SaveAll();
        }

        public async Task<ProductsViewModel> GetById(int idProduct)
        {
            var product = await _repo.GetProductsById(idProduct);
            var productoView = _mapper.Map<ProductsViewModel>(product);
            return productoView;
        }
    }
}
