using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Garago.Data.Repos;
using Garago.Domain;    

namespace Garago.Services.ViewModels.Utils
{
    public class FilterVM
    {

        public string CurrentFilter { get; set; }

        public string UserFilter { get; set; }

        public string CurrentValue { get; set; }
        
    }
}
