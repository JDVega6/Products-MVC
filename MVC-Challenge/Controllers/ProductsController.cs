using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Challenge.Data.Repositorys;
using MVC_Challenge.Domain.Services;
using MVC_Challenge.Models;

namespace MVC_Challenge.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServicesProducts _services;

        public ProductsController(IServicesProducts services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {

            var products = await _services.GetProductsAsync();
            //var products = GetData();
            return View(products);
        }

        //public IActionResult Product(int idProduct)
        //{
        //    Products modelProduct = new Products();

        //    ViewBag.Accion = "New Product";


        //    if (idProduct != 0)
        //    {
        //        ViewBag.Accion = "Edit Product";
        //        //modelProduct = await _servicioApi.GetById(idProduct);
        //    }

        //    return View(modelProduct);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Save(Products product)
        //{
        //    var productoToCreate = _mapper.Map<Products>(product);

        //    if (((int)productoToCreate.Type) < 0 || ((int)productoToCreate.Type) > 3)
        //    {
        //        return NotFound("The type is out of range");
        //    }

        //    _repo.Add(productoToCreate);
        //    if (await _repo.SaveAll())
        //        return Ok(productoToCreate);

        //    return BadRequest();


        //}



        public List<ProductsViewModel> GetData()
        {
            List<ProductsViewModel> products = new List<ProductsViewModel>();
            products.Add(new ProductsViewModel { Id = 1, Description = "Country hous", Type = (EntityTypeOption)1, Value = 5000000, Status = (EntityStatus)1 });
            products.Add(new ProductsViewModel { Id = 2, Description = "Country", Type = (EntityTypeOption)2, Value = 540000, Status = (EntityStatus)1 });
            products.Add(new ProductsViewModel { Id = 1, Description = "House", Type = (EntityTypeOption)1, Value = 5000000, Status = (EntityStatus)1 });

            return products;

        }
    }
}
