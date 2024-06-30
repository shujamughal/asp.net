using Microsoft.AspNetCore.Mvc;
using MVCdapperWithGenericRepoAndDI.Models;

namespace MVCdapperWithGenericRepoAndDI.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IRepository<Product> _productRepository;

		public ProductsController(IRepository<Product> productRepository)
		{
			_productRepository = productRepository;
		}

		public IActionResult Index()
		{
			IEnumerable<Product> products = _productRepository.GetAll();
			return View(products);
		}

		public IActionResult Details(int id)
		{
			Product product = _productRepository.GetById(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		// Other actions...
	}
}
