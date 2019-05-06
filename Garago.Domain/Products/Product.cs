using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Garago.Domain
{
    public class Product : Entity
    {
        private Product() { }
        public Product(string title, string image, double price, string description, Guid garageSaleId, bool isNew, bool isUpdated)
        {
            Title = title;
            Image = image;
            Price = price;
            Description = description;
            GarageSaleId = garageSaleId;
            if (isNew == true)
                CreatedAt = DateTime.UtcNow;
            else if (isUpdated == true)
                UpdatedAt = DateTime.UtcNow;
        }

        public string Title { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        [ForeignKey("GarageSales")]
        public Guid GarageSaleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
