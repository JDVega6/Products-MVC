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
            var productoToCreate = _mapper.Map<IEnumerable<ProductsViewModel>>(products);
            return productoToCreate;
        }
    }
}
