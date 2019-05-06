using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.User
{
    public class AddressVM
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string StateCode { get; set; }

        public int Zipcode { get; set; }

        public string City { get; set; }
    }
}
