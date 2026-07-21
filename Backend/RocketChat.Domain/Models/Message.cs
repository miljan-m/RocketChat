using System.Dynamic;

namespace RocketChat.Domain.Models
{
    public class Message
    {
        public Guid MessageId { get; set; } = new Guid();
        public string MessageText { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Message()
        {
        }
    }
}