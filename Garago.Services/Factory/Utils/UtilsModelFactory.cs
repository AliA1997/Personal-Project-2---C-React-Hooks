using Garago.Data.UtilClasses;
using Garago.Services.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.Factory.Utils
{
    public static class UtilsModelFactory
    {
        public static Filter CreateDomainModel(FilterVM filter)
        {
            return new Filter(
                    currentFilter: filter.CurrentFilter,
                    currentValue: filter.CurrentValue
                );
        }
    }
}
