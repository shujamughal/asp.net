using Core.Entities;
using Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
           //db code comes here
           List<Product> products = new List<Product>();
            products.Add(new Product { Id=1, Name="P1" , Description="P1 Description" });
            products.Add(new Product { Id = 2, Name = "P2", Description = "P2 Description" });
            products.Add(new Product { Id = 3, Name = "P3", Description = "P3 Description" });

            return products;
        }
    }
}
