using Application.Services;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly GetAllProductsUseCase _getAllProductsUseCase;
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        /*public ProductsController(GetAllProductsUseCase getAllProductsUseCase)
        {
            _getAllProductsUseCase = getAllProductsUseCase;
        }*/
        public IActionResult Index()
        {
            //var products = _getAllProductsUseCase.Execute();
            var products = _productService.GetAllProducts();

            return View(products);
        }
    }
}
