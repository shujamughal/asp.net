using Application;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetAllProductUseCase _getAllProductUseCase;

        public ProductController(GetAllProductUseCase getAllProductUseCase)
        {
            _getAllProductUseCase = getAllProductUseCase;        
        }
        public IActionResult Index()
        {
            var products= _getAllProductUseCase.GetAllProducts();
            return View(products);
        }
    }
}
