using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurulVoot.Models;
using NurulVoot.Services;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace NurulVoot.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 
        public ProductsController(JsonFileProductService productService)
        { 
            this.ProductService = productService;   
        }
        public JsonFileProductService ProductService { get; }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //[HttpPatch]"[FromBody]"
        [Route("Rate")]
        [HttpGet]

        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);    
            return Ok();
        }

    }
}
