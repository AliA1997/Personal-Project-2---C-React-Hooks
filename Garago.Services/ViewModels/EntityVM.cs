using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels
{
    public class EntityVM
    {  
        public Guid Id { get; set; }
        public bool DeletedInd { get; set; }
        public bool PermanentlyDeletedInd { get; set; }
    }
}
