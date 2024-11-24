using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _productRepository.GetAllProductsAsync();
        }

        public Task AddProductAsync(Product product)
        {
            return _productRepository.AddProductAsync(product);
        }
    }
}
