using Garago.Data.UtilClasses;
using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Data.Repos
{
    public interface IProductsRepo
    {

        Task<IEnumerable<Product>> GetAllProducts(Guid garageSaleId);

        Task<IEnumerable<Product>> GetRandomProducts();

        Task<IEnumerable<Product>> FilterProducts(Guid garageSaleId, List<Filter> filters);

        Task<Product> GetProduct(Guid productId);

        Task<Product> CreateProduct(Guid garageSaleId, Product newProduct);

        Task<string> UpdateProduct(Guid productId, Product updatedProduct);

        Task<string> DeleteProduct(Guid garageSaleId, Guid productId);
    }
}
