using Garago.Services.ViewModels.GarageSale;
using Garago.Services.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.Service.GarageSales
{
    public interface IGarageSaleService
    {

        Task<IEnumerable<GarageSaleItemVM>> GetGarageSales();

        Task<IEnumerable<GarageSaleItemVM>> FilterGarageSales(FilterVM[] filters);

        Task<GarageSaleVM> GetGarageSale(Guid id);

        Task<GarageSaleVM> CreateGarageSale(GarageSaleVM newGarageSale);

        Task<string> UpdateGarageSale(Guid garageSaleId, GarageSaleVM updatedGarageSale);

        Task<string> DeleteGarageSale(Guid garageSaleId);

    }
}
