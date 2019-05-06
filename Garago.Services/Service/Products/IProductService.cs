using Garago.Services.ViewModels.Product;
using Garago.Services.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.Service.Products
{
    public interface IProductService
    {

        Task<IEnumerable<ProductItemVM>> GetProductsForGarageSale(Guid garageSaleId);

        Task<IEnumerable<ProductItemVM>> GetRandomProducts();

        Task<IEnumerable<ProductItemVM>> FilterProducts(Guid garageSaleId, FilterVM[] filters);

        Task<ProductVM> GetProduct(Guid garageSaleId, Guid productId);

        Task<ProductVM> CreateProduct(Guid garageSaleId, ProductVM newProduct);

        Task<string> UpdateProduct(Guid garageSaleId, Guid productId, ProductVM updatedProduct);

        Task<string> DeleteProduct(Guid garageSaleId, Guid productId);

    }
}
