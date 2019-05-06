using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Garago.Data.UtilClasses;
using Garago.Repo.Utils;

namespace Garago.Data.Repos.GarageSales.Impl
{
    public class GarageSaleRepo : IGarageSaleRepo
    {
        private GaragoContext _context;
        public GarageSaleRepo(GaragoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GarageSale>> GetGarageSales()
        {
            IEnumerable<GarageSale> garageSalesToReturn = await _context.GarageSales.Where(gs => gs.DeletedInd != true).Take(30).ToListAsync();
            return garageSalesToReturn;
        }

        public async Task<IEnumerable<GarageSale>> FilterGarageSales(List<Filter> filters)
        {
            //Create a generic asynchronous callback or what microsoft calls execute work, and have a asynchronous action.
            return await Task.Run(() =>
            {
                List<GarageSale> garageSalesToReturn = new List<GarageSale>() { };
                foreach (var filter in filters)
                {
                    var temp = _context.GarageSales.Where(gs => FilterUtils.CheckGarageSaleFilter(gs, filter)).Take(250);
                    //Add all the values found in the array.
                    garageSalesToReturn.AddRange(temp);
                }
                //THen get the distinct values and then convert to a list again
                garageSalesToReturn = garageSalesToReturn.Distinct().ToList();
                //THen finally return the garageSalesToReturn;
                return garageSalesToReturn;

            });
        }

        public async Task<GarageSale> GetGarageSale(Guid garageSaleId)
        {
            GarageSale garageSaleToReturn = await _context.GarageSales.FirstOrDefaultAsync(gs => gs.Id == garageSaleId);
            return garageSaleToReturn;
        }

        public GarageSale GetGarageSaleNotAsync(Guid garageSaleId)
        {
            GarageSale garageSaleToReturn = _context.GarageSales.FirstOrDefault(gs => gs.Id == garageSaleId);
            return garageSaleToReturn;
        }

        public async Task<GarageSale> CreateGarageSale(GarageSale newGarageSale)
        {
            await _context.GarageSales.AddAsync(newGarageSale);
            await _context.SaveChangesAsync();
            return newGarageSale;
        }

        public async Task<string> UpdateGarageSale(Guid garageSaleId, GarageSale updatedGarageSale)
        {
            await Task.Run(() =>
            {
                updatedGarageSale.Id = garageSaleId;
                _context.GarageSales.Update(updatedGarageSale);
            });

            await _context.SaveChangesAsync();

            return $"Garage Sale: {updatedGarageSale.Title} has been updated.";
        }

        public async Task<string> DeleteGarageSale(Guid garageSaleId)
        {
            GarageSale garageSaleToDelete = await _context.GarageSales.FirstOrDefaultAsync(gs => gs.Id == garageSaleId);

            await Task.Run(() =>
            {
                garageSaleToDelete.DeletedInd = true;
                garageSaleToDelete.DeletedAt = DateTime.Now;
                _context.GarageSales.Update(garageSaleToDelete);
            });

            await _context.SaveChangesAsync();

            return $"Garage Sale: {garageSaleToDelete.Title} has been deleted.";
        }

    }
}
