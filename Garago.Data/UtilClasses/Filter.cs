using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Data.UtilClasses
{
    public class Filter
    {
        public string CurrentFilter { get; set; }

        public string CurrentValue { get; set; }

        public Filter(string currentFilter, string currentValue)
        {
            CurrentFilter = currentFilter;
            CurrentValue = currentValue;
        }

    }
}
