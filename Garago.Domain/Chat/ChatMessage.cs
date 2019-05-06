using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Garago.Domain.Chat
{
    public class ChatMessage : Entity
    {
        private ChatMessage() { }
        public ChatMessage(Guid chatId, string body)
        {
            ChatId = chatId;
            Body = body;
            CreatedAt = DateTime.UtcNow;
        }

        [ForeignKey("Chats")]
        public Guid ChatId { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
