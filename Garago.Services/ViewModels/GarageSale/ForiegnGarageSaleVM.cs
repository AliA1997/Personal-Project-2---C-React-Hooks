using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.GarageSale
{
    public class ForiegnGarageSaleVM : EntityVM
    {
        public string Title { get; set; }

        public DateTime DateOfSale { get; set; }
        
        public string Location { get; set; }

        public string Link
        {
            get
            {
                return $"http://localhost:8080/garage_sales/{Id}";
            }
        }
    }
}
