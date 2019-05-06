using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Account
{
    public class FBResponseVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public FBPictureDataContainer Picture { get; set; }
    }
    public class FBPictureDataContainer
    {
        public FBPictureData Data { get;set; }
    }
    public class FBPictureData
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public bool is_silhouette { get; set; }
        public string Url { get; set; }
    }
}
