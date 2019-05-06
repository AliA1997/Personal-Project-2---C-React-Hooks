using Garago.Data.Repos;
using Garago.Services.Factory.GarageSales;
using Garago.Services.ViewModels.GarageSale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garago.Domain;
using Garago.Services.ViewModels.Utils;
using Garago.Data.UtilClasses;
using Garago.Services.Factory.Utils;

namespace Garago.Services.Service.GarageSales.Impl
{
    public class GarageSaleService : IGarageSaleService
    {
        private IGarageSaleRepo _garageSaleRepo;
        private IUsersRepo _userRepo;
        public GarageSaleService(IGarageSaleRepo garageSaleRepo, IUsersRepo userRepo)
        {
            _garageSaleRepo = garageSaleRepo;
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<GarageSaleItemVM>> GetGarageSales()
        {

            IEnumerable<GarageSale> garageSaleItemsToConvert = await _garageSaleRepo.GetGarageSales();
            IEnumerable<GarageSaleItemVM> garageSaleItemsToReturn = garageSaleItemsToConvert.Select(gs =>
                                                                                            {
                                                                                                var user = _userRepo.GetUserNotAsync(gs.CreatedBy);
                                                                                                return GarageSaleModelFactory.CreateItemViewModel(gs, user);
                                                                                            });
            return garageSaleItemsToReturn;
        }

        public async Task<IEnumerable<GarageSaleItemVM>> FilterGarageSales(FilterVM[] filters)
        {
            //Define a new of filters to loop be used in our filterGarageSales method.
            List<Filter> filtersToPass = new List<Filter>();
            //Then run a asynchronous task or action
            await Task.Run(() =>
            {
                //Then foreach filter in the filters list add a new filter to pass after converting it to it's corresponding domain model.
                foreach (FilterVM filter in filters)
                {
                    filtersToPass.Add(UtilsModelFactory.CreateDomainModel(filter));
                }

            });

            //After the task is finished, filter garageSales using that array
            IEnumerable<GarageSale> garageSalesToConvert = await _garageSaleRepo.FilterGarageSales(filtersToPass);

            //THen convert each garage sale to a garageSale vm item.
            IEnumerable<GarageSaleItemVM> garageSalesToReturn = garageSalesToConvert.Select(gs =>
                                                                                        {
                                                                                            var user = _userRepo.GetUserNotAsync(gs.CreatedBy);
                                                                                            return GarageSaleModelFactory.CreateItemViewModel(gs, user);
                                                                                        });
            //Then return the converted garage sales.
            return garageSalesToReturn;
        }

        public async Task<GarageSaleVM> GetGarageSale(Guid garageSaleId)
        {
            GarageSale garageSaleToConvert = await _garageSaleRepo.GetGarageSale(garageSaleId);
            GaragoUser garageSaleUser = await _userRepo.GetUser(garageSaleToConvert.CreatedBy);
            GarageSaleVM garageSaleToReturn = GarageSaleModelFactory.CreateViewModel(garageSaleToConvert, garageSaleUser);
            return garageSaleToReturn;
        }
        

        public async Task<GarageSaleVM> CreateGarageSale(GarageSaleVM newGarageSale)
        {
            GarageSale garageSaleToCreate = GarageSaleModelFactory.CreateDomainModel(newGarageSale, true);
            await _garageSaleRepo.CreateGarageSale(garageSaleToCreate);
            return newGarageSale;
        }

        public async Task<string> UpdateGarageSale(Guid garageSaleId, GarageSaleVM updatedGarageSale)
        {
            GarageSale garageSaleToUpdate = GarageSaleModelFactory.CreateDomainModel(updatedGarageSale, false);
            string message = await _garageSaleRepo.UpdateGarageSale(garageSaleId, garageSaleToUpdate);
            return message;
        }

        public async Task<string> DeleteGarageSale(Guid garageSaleId)
        {
            string message = await _garageSaleRepo.DeleteGarageSale(garageSaleId);
            return message;
        }

    }
}
