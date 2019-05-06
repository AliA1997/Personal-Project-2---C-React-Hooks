using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Garago.Data.UtilClasses;
using Garago.Repo.Utils;
using Newtonsoft.Json;

namespace Garago.Data.Repos.Products.Impl
{
    public class ProductsRepo : IProductsRepo
    {
        private GaragoContext _context;
        public ProductsRepo(GaragoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(Guid garageSaleId)
        {
            IEnumerable<Product> productsToReturn = await _context.Products.Where(product => product.GarageSaleId == garageSaleId && product.DeletedInd != true).ToListAsync();
            return productsToReturn;
        }

        public async Task<IEnumerable<Product>> GetRandomProducts()
        {
            IEnumerable<Product> productsToReturn = new List<Product>();
            await Task.Run(async () =>
            {
                for(var i = 0; i < 10; i++)
                {
                    //Generate a random number which would be a random index to be used to get random products based on 'it garage sale id.
                    int randomGarageSaleIndex = new Random().Next(40);
                    //Turn the context.GarageSales into a list in order to use a index then retrieve the id of the selected garage sale.
                    var garageSales = await _context.GarageSales.ToListAsync();
                    var randomGarageSaleId = garageSales[randomGarageSaleIndex].Id;
                    var tempProducts = _context.Products.Select(prod => prod).Where(p => p.GarageSaleId == randomGarageSaleId).Take(2);
                    productsToReturn.Concat(tempProducts);
                }
        
            });
            return productsToReturn;
        }

        public async Task<IEnumerable<Product>> FilterProducts(Guid garageSaleId, List<Filter> filters)
        {
            List<Product> productsToReturn = new List<Product>();
            await Task.Run(() =>
            {
                foreach (Filter filter in filters)
                {
                    var temp = _context.Products.Where(prod => FilterUtils.CheckProductsFilter(prod, prod.GarageSaleId, filter)).Take(250);
                    productsToReturn.AddRange(temp);
                 }
            });

            productsToReturn = productsToReturn.Distinct().ToList();

            return productsToReturn;
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            Product productToReturn = await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);
            return productToReturn;
        }

        public async Task<Product> CreateProduct(Guid garageSaleId, Product newProduct)
        {
            var garageSaleToUpdate = await _context.GarageSales.FirstOrDefaultAsync(gs => gs.Id == garageSaleId);

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync();

            //Update the garageSales products string.
            await Task.Run(() =>
            {
                var garageSaleProducts = _context.Products.Where(prod => prod.GarageSaleId == garageSaleId);
                garageSaleToUpdate.ProductString = JsonConvert.SerializeObject(garageSaleProducts);
                _context.GarageSales.Update(garageSaleToUpdate);
                _context.SaveChanges();
            });

            return newProduct;
        }

        public async Task<string> UpdateProduct(Guid productId, Product updatedProduct)
        {
            await Task.Run(() =>
            {
                updatedProduct.Id = productId;
                _context.Products.Update(updatedProduct);
            });
            await _context.SaveChangesAsync();
            return $"Product: {updatedProduct.Title} has been updated.";
        }

        public async Task<string> DeleteProduct(Guid garageSaleId, Guid productId)
        {
            Product productToDelete = await _context.Products.FirstOrDefaultAsync(product => product.Id == productId);

            GarageSale garageSaleToUpdate = await _context.GarageSales.FirstOrDefaultAsync(gs => gs.Id == garageSaleId);

            await Task.Run(() =>
            {
                productToDelete.DeletedInd = true;
                productToDelete.DeletedAt = DateTime.Now;
                _context.Products.Update(productToDelete);
            });

            await Task.Run(() =>
            {
                var garageSaleProducts = _context.Products.Where(prod => prod.GarageSaleId == garageSaleId);
                garageSaleToUpdate.ProductString = JsonConvert.SerializeObject(garageSaleProducts);
                _context.GarageSales.Update(garageSaleToUpdate);
            });

            await _context.SaveChangesAsync(); 
           
            return $"Product: {productToDelete.Title} has been deleted!";
        }
    }
}
