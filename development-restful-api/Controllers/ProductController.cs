using development_restful_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace development_restful_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductList _productList;

        public ProductController(ProductList productList)
        {
            _productList = productList;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productList.Products;
            if(products == null || products.Count == 0) { return NotFound(); }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productList.Products.Find(x => x.Id == id);
            
            if(product == null)
            {
                return NotFound(new ErrorModel { Message = "Not found product"});
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorModel { Message = "Is not valid product data" });
            }

            try
            {
                int newId = _productList.Products.Max(p => p.Id) + 1; // Yeni bir ID oluşturma
                product.Id = newId;

                _productList.Products.Add(product);

                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorModel { Message = "An error request" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorModel { Message = "Is not valid product data" });
            }

            var existingProduct = _productList.Products.Find(p => p.Id == id);

            try
            {
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    // Diğer güncelleme işlemleri...

                    return NoContent();
                }
                else
                {
                    return NotFound(new ErrorModel { Message = "Product not found" });
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ErrorModel { Message = "An error occurred while processing the request" });
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productList.Products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new ErrorModel { Message = "Product not found" });
            }

            try
            {
                _productList.Products.Remove(product);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ErrorModel { Message = "An error occurred while processing the request" });
            }
        }
    }
}
