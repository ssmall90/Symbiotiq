using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Net.Mail;
using System.Text.Json.Serialization;

namespace Symbiotiq_Balzor_Ui.Models
{
    public class MessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string SenderNotification { get; set; }
        public string ReceiverNotification { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public bool isCompleted { get; set; }
        public bool isConfirmed { get; set; }
        public bool isDeleted { get; set; }

        [JsonConstructor]
        public MessageModel(string id, string Title, string senderNotification, string receiverNotification, string Sender, string Receiver)
        {
            Id = id;
            this.Title = Title;
            this.SenderNotification = senderNotification;
            this.ReceiverNotification = receiverNotification;
            this.Sender = Sender;
            this.Receiver = Receiver;
            isCompleted = false;
            isConfirmed = false;
            isDeleted = false;
        }

        public MessageModel(string title, string senderNotification, string receiverNotification, string sender, string receiver)
        {
            this.Title = title;
            this.SenderNotification = senderNotification;
            this.ReceiverNotification = receiverNotification;
            this.Sender = sender;
            this.Receiver = receiver;
            isCompleted = false;
            isConfirmed = false;
            isDeleted = false;
        }
    }


}
