using Garago.Services.ViewModels.GarageSale;
using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Garago.Services.Factory.User;

namespace Garago.Services.Factory.GarageSales
{
    //Have a static class for creating view  models for displaying garage sale data, and domain models for create garage sale data.
    public static class GarageSaleModelFactory
    {
        //This method will be responsible for create a new GarageSale View Model.
        public static ForiegnGarageSaleVM CreateForiegnViewModel(GarageSale garageSale)
        {
            return new ForiegnGarageSaleVM()
            {
                Id = garageSale.Id,
                Title = garageSale.Title,
                DateOfSale = garageSale.DateOfSale,
                Location = garageSale.Location
            };
        }

        //This method will be responsible for create a new GarageSale View Model.
        public static GarageSaleVM CreateViewModel(GarageSale garageSale, GaragoUser user)
        {
            return new GarageSaleVM()
            {
                Id = garageSale.Id,
                AdImage = garageSale.AdImage,
                Title = garageSale.Title,
                Description = garageSale.Description,
                DateOfSale = garageSale.DateOfSale,
                Chats = garageSale.ChatsString,
                Location = garageSale.Location,
                Products = garageSale.ProductString,
                Reviews = garageSale.ReviewString,
                CreatedBy = user != null ? UserModelFactory.CreateViewModel(user, false) : null,
                Created_At = garageSale.CreatedAt,
                Updated_At = garageSale.UpdatedAt
            };
        }

        //This method will be responsible for create a new GarageSale Item View Model.
        public static GarageSaleItemVM CreateItemViewModel(GarageSale garageSale, GaragoUser user)
        {
            return new GarageSaleItemVM()
            {
                Id = garageSale.Id,
                Title = garageSale.Title,
                AdImage = garageSale.AdImage,
                Description = garageSale.Description,
                Location = garageSale.Location,
                CreatedBy = UserModelFactory.CreateViewModel(user, false),
                DateOfSale = garageSale.DateOfSale
            };
        }

        //This method will be responsible for create a new GarageSale Domain Model.
        public static GarageSale CreateDomainModel(GarageSaleVM garageSaleForm, bool isNew)
        {
            return new GarageSale(
                    createdBy: garageSaleForm.CreatedBy.Id,
                    title: garageSaleForm.Title,
                    products: garageSaleForm.Products,
                    reviews: garageSaleForm.Reviews,
                    chats: garageSaleForm.Chats,
                    adImage: garageSaleForm.AdImage,
                    description: garageSaleForm.Description,
                    location: garageSaleForm.Location,
                    dateOfSale: garageSaleForm.DateOfSale,
                    isNew: isNew, 
                    isUpdated: isNew == true ? false : true
                );
        }
    }
}
