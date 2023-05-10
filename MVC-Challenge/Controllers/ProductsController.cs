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
    public class ProductsController : Controller
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
            if (!String.IsNullOrEmpty(description))
            {
                productList = await _services.GetByDescriptionAsync(description);
            }
            return View(productList);
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
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NoContent();
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
