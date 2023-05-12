using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Challenge.Data.Models;
using MVC_Challenge.Data.Repositorys;
using MVC_Challenge.Domain.Dtos;
using MVC_Challenge.Domain.Services;
using MVC_Challenge.Models;

namespace MVC_Challenge.Controllers
{
    public class ProductsController : AlertsBoostrapController
    {
        private readonly IServicesProducts _services;
        private readonly IProductsRepository _repo;

        public ProductsController(IServicesProducts services, IProductsRepository repo)
        {
            _services = services;
            _repo = repo;
        }

        public async Task<IActionResult> Index(string description)
        {
            var productList = await _services.GetProductsAsync();
            ProductsViewModel product = new ProductsViewModel();

            if (!String.IsNullOrEmpty(description))
            {
                if (int.TryParse(description, out int number))
                    product = await _services.GetById(number);
                else
                    productList = await _services.GetByDescriptionAsync(description);
            }

            Success("The information was loaded correctly.");
            ViewBag.Products = productList;

            if (productList.Count() == 0)
            {
                Warning("There are no products available");
            }
            if (product == null)
            {
                ProductsViewModel productError = new ProductsViewModel();
                Danger("The product is not found in the database..");
                return View(productError);
            }
            return View(product);
        }

        // GET:localhost:puerto/Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto product)
        {
            try
            {
                ViewBag.Accion = "New Product";
                var response = await _services.Create(product);
                Info("The product was created successfully.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                Danger("The product creation was unsuccessful.");
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET:localhost:puerto/Producto/Create
        public async  Task<IActionResult> Update(int idProduct)
        {
            ViewBag.Accion = "Edit Product";
            var modelProduct = await _services.GetById(idProduct);
            return View(modelProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            try
            {
                var response = await _services.Update(product);
                Info("The product was successfully updated.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NoContent();
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int idProduct)
        {
            try
            {
                await _services.DeleteById(idProduct);
                TempData["sms"] = "Se elimino el registro exitosamente";
                ViewBag.sms = TempData["sms"];
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NoContent();
                throw;
            }
        }
    }
}
