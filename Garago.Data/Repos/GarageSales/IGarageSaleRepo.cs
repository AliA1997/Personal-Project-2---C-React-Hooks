using Garago.Data.UtilClasses;
using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Data.Repos
{
    public interface IGarageSaleRepo
    {
        Task<IEnumerable<GarageSale>> GetGarageSales();

        Task<IEnumerable<GarageSale>> FilterGarageSales(List<Filter> filters);

        Task<GarageSale> GetGarageSale(Guid garageSaleId);

        GarageSale GetGarageSaleNotAsync(Guid garageSaleId);

        Task<GarageSale> CreateGarageSale(GarageSale newGarageSale);

        Task<string> UpdateGarageSale(Guid garageSaleId, GarageSale updatedGarageSale);

        Task<string> DeleteGarageSale(Guid garageSaleId);

    }
}
