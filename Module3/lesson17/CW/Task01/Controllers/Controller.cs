using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Task01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>(new[] {
            new Product() { Id = 1, Name = "Notebook", Price = 100000 },
            new Product() { Id = 2, Name = "Car", Price = 2000000 },
            new Product() { Id = 3, Name = "Apple", Price = 30 },
        });
        
        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        
        // Done till the end in following HW.
    }
}