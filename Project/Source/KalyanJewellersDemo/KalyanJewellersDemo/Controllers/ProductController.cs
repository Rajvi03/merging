using KalyanJewellersDemo.IServices;
using KalyanJewellersDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Controllers
{
    [Route("KalyanJewellers")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService { get; set; }

        public ProductController(IProductService service)
        {
            productService = service;
        }
        [HttpGet("Products")]
        public IActionResult getAllProducts()
        {
            try
            {
                return Ok(productService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Product/{id}")]
        public IActionResult getAnProduct(int id)
        {
            try
            {
                return Ok(productService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("addProduct")]
        public IActionResult postProduct(Product product)
        {
            try
            {
                return Ok(productService.Add(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("edit/{id}")]
        public IActionResult putProduct(int id, Product product)
        {
            try
            {
                var anProduct = productService.GetById(id);
                return Ok(productService.Put(anProduct, product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult deleteProduct(int id)
        {
            try
            {
                var anProduct = productService.GetById(id);
                return Ok(productService.Delete(anProduct));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
