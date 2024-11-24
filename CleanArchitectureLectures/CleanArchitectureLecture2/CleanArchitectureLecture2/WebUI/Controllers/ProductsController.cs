using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
        public class ProductsController : Controller
        {
            private readonly ProductService _productService;

            public ProductsController(ProductService productService)
            {
                _productService = productService;
            }

            public async Task<IActionResult> Index()
            {
                var products = await _productService.GetProductsAsync();
                return View(products);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Product product)
            {
                if (ModelState.IsValid)
                {
                    await _productService.AddProductAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
        }
}
