using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garago.Services.Service.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garago.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var productsToReturn = await _productService.GetRandomProducts();
            return Ok(productsToReturn);
        }
    }
}