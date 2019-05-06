using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Garago.Data.Repos;
using Garago.Domain;
using Garago.Data.UtilClasses;

namespace Garago.Repo.Utils
{
    public class FilterUtils
    {
        private IUsersRepo _userRepo;

        public FilterUtils(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public static bool CheckGarageSaleFilter(GarageSale gs, Filter filter)
        {
            if (filter.CurrentFilter == "Title" && gs.Title.Contains(filter.CurrentValue))
                return true;

            else if (filter.CurrentFilter == "DateOfSale"
                    && (gs.DateOfSale.Equals(filter.CurrentValue)
                    || gs.DateOfSale.ToString().Contains(filter.CurrentValue)))
                return true;

            else if (filter.CurrentFilter == "Description" && gs.Description.Contains(filter.CurrentValue))
                return true;

            else if (filter.CurrentFilter == "" && gs.Location.Contains($"location: ${filter.CurrentValue}"))
                return true;

            return false;
        }

        public static bool CheckProductsFilter(Product prod, Guid gsId, Filter filter)
        {
            if (prod.GarageSaleId == gsId)
            {
                if (filter.CurrentFilter == "Title" && prod.Title.Contains(filter.CurrentValue))
                    return true;

                else if (filter.CurrentFilter == "Description" && prod.Description.Contains(filter.CurrentValue))
                    return true;

                else if (filter.CurrentFilter == "Price" && prod.Price == double.Parse(filter.CurrentValue))
                    return true;

                else if (filter.CurrentFilter == "CreatedAt"
                        && (prod.CreatedAt.Equals(filter.CurrentValue)
                        || prod.CreatedAt.ToString().Contains(filter.CurrentValue))
                        )
                    return true;

                else
                    return false;

            }
            return false;
        }

        public static bool CheckUserFilter(GaragoUser user, Filter filter)
        {
            if (filter.CurrentFilter == "Email" && user.Email.Contains(filter.CurrentValue))
                return true;

            else if (filter.CurrentFilter == "Name" && user.Name.Contains(filter.CurrentValue))
                return true;

            else if (filter.CurrentFilter == "Username" && user.UserName.Contains(filter.CurrentValue))
                return true;

            else if (filter.CurrentFilter == "Address"
                    && (user.Address1.Contains(filter.CurrentValue)
                    || user.Address2.Contains(filter.CurrentValue)
                    || user.Address3.Contains(filter.CurrentValue)
                    || user.FullAddress.Contains(filter.CurrentValue)
                    || user.City.Contains(filter.CurrentValue)
                    ))
                return true;

            else if (filter.CurrentFilter == "Phone #" && user.PhoneNumber.ToString().Contains(filter.CurrentValue))
                return true;

            else
                return false;
        }

    }
}
