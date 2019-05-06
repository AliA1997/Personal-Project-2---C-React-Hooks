using Garago.Domain;
using Garago.Services.ViewModels.Account;
using Garago.Services.ViewModels.User;
using Garago.Services.ViewModels.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.Factory.User
{
    public static class UserModelFactory
    {
        public static ForiegnUserVM CreateViewModel(GaragoUser user, bool isAdmin)
        {
            if (isAdmin == true)
                return new ForiegnUserVM()
                {
                    Id = Guid.Parse(user.Id),
                    DisplayName = user.UserName,
                    Avatar = user.Avatar,
                    DeletedInd = false,
                    PermanentlyDeletedInd = false
                };
            else
                return new ForiegnUserVM()
                {
                    Id = Guid.Parse(user.Id),
                    DisplayName = user.UserName,
                    Avatar = user.Avatar
                };
        }

        public static UserVM CreateViewModel(GaragoUser user)
        {
            return new UserVM()
            {
                Id = Guid.Parse(user.Id),
                Avatar = user.Avatar != null ? user.Avatar : "",
                Name = user.Name != null ? user.Name : "",
                DisplayName = user.UserName != null ? user.UserName : "",
                Address1 = user.Address1 != null ? user.Address1 : "",
                Address2 = user.Address2 != null ? user.Address2 : "",
                Address3 = user.Address3 != null ? user.Address3 : "",
                FullAddress = user.FullAddress != null ? user.FullAddress : "",
                City = user.City != null ? user.City : "",
                Zipcode = user.Zipcode != null ? user.Zipcode : 00000,
                StateCode = $"{user.StateCode}",
                CreatedAt = user.CreatedAt != null ? user.CreatedAt : new DateTime(),
                UpdatedAt = user.UpdatedAt != null ? user.UpdatedAt : new DateTime(),
            };
            
        }

        public static UserVM CreateViewModelFromResponse(string responseData, ThirdParty type)
        {
            FBResponseVM userInfo;
            if(type == ThirdParty.Facebook)
                userInfo = JsonConvert.DeserializeObject<FBResponseVM>(responseData);
            
            return new UserVM()
            {
                
            };
        }

        public static UserItemVM CreateItemViewModel(GaragoUser user)
        {
            return new UserItemVM()
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.UserName,
                Avatar = user.Avatar,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            };
        }
    }
}
