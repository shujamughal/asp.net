using Microsoft.AspNetCore.Mvc;

namespace ViewComponentTut.Components
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class SimilarProductsViewComponent : ViewComponent
    {
        public static List<Product> products = new List<Product>
        {
            new Product {Id=1,Name="Product 1",Category="Men" },
            new Product {Id=2,Name="Product 2",Category="Men" },
            new Product {Id=3,Name="Product 3",Category="Men" },
            new Product {Id=4,Name="Product 4",Category="Women" },
            new Product {Id=5,Name="Product 5",Category="Women" },
            new Product {Id=6,Name="Product 6",Category="Women" },
            new Product {Id=7,Name="Product 7",Category="Kids" },
            new Product {Id=8,Name="Product 8",Category="Kids" },
            new Product {Id=9,Name="Product 9",Category="Kids" },
        };
        public IViewComponentResult Invoke(string category, int productId)
        {
            //getting all the product related to received category
            var list = products.Where(x => x.Category == category).ToList();

            //now remove the received product from the list so that it doesn't appear in similar products
            foreach (var product in list.ToList())
            {
                if (product.Id == productId)
                {
                    list.Remove(product);
                    break;
                }
            }

            return View(list);
        }
    }
}