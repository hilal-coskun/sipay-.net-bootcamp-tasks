using System.Collections.Generic;

namespace development_restful_api.Models
{
    public class ProductList
    {
        public List<Product> Products { get; set; }

        public ProductList()
        {
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 0.99 },
                new Product { Id = 2, Name = "Product 2", Price = 29.99 },
            };
        }
    }
}
