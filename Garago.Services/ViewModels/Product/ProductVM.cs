using Garago.Services.ViewModels.GarageSale;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Product
{
    public class ProductVM : EntityVM
    {
        public string Title { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public ForiegnGarageSaleVM GarageSaleInfo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
