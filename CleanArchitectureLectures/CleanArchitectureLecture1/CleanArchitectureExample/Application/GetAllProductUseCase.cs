using Core.Entities;
using Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GetAllProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductUseCase(IProductRepository productRepository) { 
        _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts() {
            return _productRepository.GetAll();
        }
    }
}
