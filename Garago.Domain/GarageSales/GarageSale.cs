using Garago.Domain.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Garago.Domain
{
    public class GarageSale : Entity
    {
        private GarageSale() { }

        public GarageSale(Guid createdBy, string title, string products, string reviews, string chats, string adImage, string description, string location, DateTime dateOfSale, bool isNew, bool isUpdated)
        {
            Title = title;
            AdImage = adImage;
            Description = description;
            ProductString = products;
            ReviewString = reviews;
            ChatsString = chats;
            CreatedBy = createdBy;
            Location = location;
            DateOfSale = dateOfSale;
            if (isNew == true)
                CreatedAt = DateTime.UtcNow;
            else if (isUpdated == true)
                UpdatedAt = DateTime.UtcNow;
        }

        public string Title { get; set; }

        public string AdImage { get; set; }

        public string Description { get; set; }

        [ForeignKey("GaragoUsers")]
        public Guid CreatedBy { get; set; }

        public ICollection<Product> Products { get; set; }

        public string ProductString { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public string ReviewString { get; set; }

        public ICollection<GaragoChat> Chats { get; set; }

        public string ChatsString { get; set; }

        public string Location { get; set; }

        public DateTime DateOfSale { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

    }
}
