using Garago.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.GarageSale
{
    public class GarageSaleVM : EntityVM
    {
        public string Title { get; set; }
        public string AdImage { get; set; }
        public ForiegnUserVM CreatedBy { get; set;}
        public string Description { get; set; }
        public string Location { get; set; }
        public string Products { get; set; }
        public string Reviews { get; set; }
        public string Chats { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}
