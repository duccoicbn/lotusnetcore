using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Final.Entities;
using WebAPI_Final.IServices;
using WebAPI_Final.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Final.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsServices productsServices;

        public ProductsController()
        {
            productsServices = new ProductsServices();
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsServices.GetProducts());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddProducts([FromBody]Products product)
        {
            return Ok(productsServices.AddProducts(product));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult UpdateProducts([FromBody] Products product)
        {
            return Ok(productsServices.UpdateProducts(product));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProductFromID(int id)
        {
            return Ok(productsServices.DeleteProductsFromID(id));
        }
    }
}

