using Garago.Data.Repos;
using Garago.Data.Repos.Products.Impl;
using Garago.Domain;
using Garago.Services.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Garago.Services.Factory.Products;
using Garago.Services.ViewModels.Utils;
using Garago.Data.UtilClasses;
using Garago.Services.Factory.Utils;

namespace Garago.Services.Service.Products.Impl
{
    public class ProductService : IProductService
    {
        private IProductsRepo _productRepo;
        private IGarageSaleRepo _garageSaleRepo;

        public ProductService(IProductsRepo productRepo, IGarageSaleRepo garageSaleRepo)
        {
            _productRepo = productRepo;
            _garageSaleRepo = garageSaleRepo;
        }

        public async Task<IEnumerable<ProductItemVM>> GetProductsForGarageSale(Guid garageSaleId)
        {
            GarageSale garageSaleToUse = await _garageSaleRepo.GetGarageSale(garageSaleId);
            IEnumerable<Product> productsToConvert = await _productRepo.GetAllProducts(garageSaleId);
            IEnumerable<ProductItemVM> productsToReturn = productsToConvert.Select(pr => ProductModelFactory.CreateItemViewModel(pr, garageSaleToUse));
            return productsToReturn;
        }

        public async Task<IEnumerable<ProductItemVM>> GetRandomProducts()
        {
            var productsToConvert = await _productRepo.GetRandomProducts();
            var productsToReturn = productsToConvert.Select(prod =>
            {
                var garageSaleToUse =  _garageSaleRepo.GetGarageSaleNotAsync(prod.GarageSaleId);
                return ProductModelFactory.CreateItemViewModel(prod, garageSaleToUse);
            });
            return productsToReturn;
        }

        public async Task<IEnumerable<ProductItemVM>> FilterProducts(Guid garageSaleId, FilterVM[] filters)
        {
            List<Filter> filtersToUse = new List<Filter>();

            await Task.Run(() =>
            {
                foreach(FilterVM filter in filters)
                {
                    filtersToUse.Add(UtilsModelFactory.CreateDomainModel(filter));
                }
            });

            //Get the garageSale to retrieve the garageSale info for each product item.
            var garageSale = await _garageSaleRepo.GetGarageSale(garageSaleId);

            var productsToConvert = await _productRepo.FilterProducts(garageSaleId, filtersToUse);

            IEnumerable<ProductItemVM> productsToReturn = productsToConvert.Select(prod => ProductModelFactory.CreateItemViewModel(prod, garageSale));

            return productsToReturn;
        }


        public async Task<ProductVM> GetProduct(Guid garageSaleId, Guid productId)
        {
            Product productToConvert = await _productRepo.GetProduct(productId);
            GarageSale garageSaleToUse = await _garageSaleRepo.GetGarageSale(garageSaleId);
            ProductVM productToReturn = ProductModelFactory.CreateViewModel(productToConvert, garageSaleToUse);
            return productToReturn;
        }

        public async Task<ProductVM> CreateProduct(Guid garageSaleId, ProductVM newProduct)
        {
            var productToCreate = ProductModelFactory.CreateDomainModel(newProduct, true);
            await _productRepo.CreateProduct(garageSaleId, productToCreate);
            return newProduct;
        }

        public async Task<string> UpdateProduct(Guid garageSaleId, Guid productId, ProductVM updatedProduct)
        {
            var productToUpdate = ProductModelFactory.CreateDomainModel(updatedProduct, false);
            string message = await _productRepo.UpdateProduct(productId, productToUpdate);
            return message;
        }

        public async Task<string> DeleteProduct(Guid garageSaleId, Guid productId)
        {
            string message = await _productRepo.DeleteProduct(garageSaleId, productId);
            return message;
        }
    }
}
