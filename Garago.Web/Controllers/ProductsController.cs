using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Garago.Services.Service.Products;
using Garago.Services.ViewModels.Product;

namespace Garago.Web.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("api/garage_sales")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{garageSaleId}/products")]
        public async Task<IActionResult> Get(Guid garageSaleId)
        {
            var productsToReturn = await _productService.GetProductsForGarageSale(garageSaleId);
            return Ok(productsToReturn);
        }

        [HttpGet("{garageSaleId}/products/{id}")]
        public async Task<IActionResult> GetProduct(Guid garageSaleId, Guid id)
        {
            var productToReturn = await _productService.GetProduct(garageSaleId, id);
            return Ok(productToReturn);
        }

        [HttpPost("{garageSaleId}/products")]
        public async Task<IActionResult> CreateProduct(Guid garageSaleId, [FromBody] ProductVM newProduct)
        {
            var productToReturn = await _productService.CreateProduct(garageSaleId, newProduct);
            return Ok(productToReturn);
        }

        [HttpPut("{garageSaleId}/products/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid garageSaleId, Guid id, [FromBody] ProductVM updatedProduct)
        {
            var message = await _productService.UpdateProduct(garageSaleId, id, updatedProduct);
            return Ok(message);
        }

        [HttpPut("{garageSaleId}/products/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid garageSaleId, Guid id)
        {
            var message = await _productService.DeleteProduct(garageSaleId, id);
            return Ok(message);
        }
    }
}