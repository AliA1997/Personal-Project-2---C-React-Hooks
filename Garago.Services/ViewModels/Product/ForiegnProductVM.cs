using Garago.Services.ViewModels.GarageSale;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Product
{
    public class ForiegnProductVM : EntityVM
    {
        public string Title { get; set; }

        public string Image { get; set; }

        public ForiegnGarageSaleVM GarageSaleInfo { get; set; }

        public double Price { get; set; }

        public string Link
        {
            get
            {
                return $"http://localhost:8080/garage_sales/{GarageSaleInfo.Id}/products/{Id}";
            }
        }

    }
}
