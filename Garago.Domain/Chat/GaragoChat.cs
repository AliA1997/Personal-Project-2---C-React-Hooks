using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Garago.Domain.Chat
{
    public class GaragoChat : Entity
    {
        private GaragoChat() { }
        public GaragoChat(Guid garageSaleId, bool isNew, bool isUpdated)
        {
            GarageSaleId = garageSaleId;

            if (isNew == true)
                CreatedAt = DateTime.UtcNow;
            else if (isUpdated == true)
                CreatedAt = DateTime.UtcNow;
        }

        [ForeignKey("GarageSales")]
        public Guid GarageSaleId { get; set; }
        
        public ICollection<ChatMessage> Messages { get; set; }

        public string MessagesString { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime LastMessageAt { get; set; }
    }
}
