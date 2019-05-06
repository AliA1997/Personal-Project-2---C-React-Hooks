using Garago.Domain;
using Garago.Services.Factory.GarageSales;
using Garago.Services.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.Factory.Products
{
    public static class ProductModelFactory
    {
        public static ForiegnProductVM CreateForiegnViewModel(Product product, GarageSale garageSale)
        {
            return new ForiegnProductVM()
            {
                Id = product.Id,
                Title = product.Title,
                Image = product.Image,
                Price = product.Price,
                GarageSaleInfo = GarageSaleModelFactory.CreateForiegnViewModel(garageSale)
            };
        }

        public static ProductVM CreateViewModel(Product product, GarageSale garageSale)
        {
            return new ProductVM()
            {
                Id = product.Id,
                Title = product.Title,  
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                GarageSaleInfo = GarageSaleModelFactory.CreateForiegnViewModel(garageSale)
            };
        }

        public static ProductItemVM CreateItemViewModel(Product product, GarageSale garageSale)
        {
            return new ProductItemVM() 
            {
               Id = product.Id,
               Title = product.Title,
               Image = product.Image,
               Price = product.Price,
               GarageSaleInfo = GarageSaleModelFactory.CreateForiegnViewModel(garageSale)
            };
        }

        public static Product CreateDomainModel(ProductVM newProduct, bool isNew)
        {
            return new Product(
                    title: newProduct.Title,
                    image: newProduct.Image,
                    price: newProduct.Price,
                    description: newProduct.Description,
                    garageSaleId: newProduct.GarageSaleInfo.Id,
                    isNew: isNew,
                    isUpdated: isNew ? false : true
                );
        }
    }
}
