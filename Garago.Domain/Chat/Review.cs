using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Garago.Domain.Chat
{
    public class Review : Entity
    {
        private Review() { }
        public Review(Guid userId, string body, double rating, bool isNew, bool isUpdated)
        {
            UserId = userId;
            Body = body;
            Rating = rating;
            if (isNew == true)
                CreatedAt = DateTime.UtcNow;
            else if (isUpdated == true)
                UpdatedAt = DateTime.UtcNow;
        }

        [ForeignKey("GaragoUsers")]
        public Guid UserId { get; set; }

        [ForeignKey("GarageSales")]
        public Guid GarageSaleId { get; set; }

        public string Body { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
