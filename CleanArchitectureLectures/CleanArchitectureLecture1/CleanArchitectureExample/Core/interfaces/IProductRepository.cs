using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IProductRepository
    {
       /* void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);*/
        List<Product> GetAll();

    }
}
