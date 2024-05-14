using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Symbiotiq_Balzor_Ui.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public string Collector { get; set; }
        public int Trustpoints { get; set; }
        public bool HasAvailableItems { get; set; }
        public bool CollectionRequested { get; set; }
        public List<NonFoodItemModel> NonFoodItemsAvailable { get; set;}
        public List<FoodItems> FoodItemsAvailable { get; set; }
        public List<MessageModel> Messages { get; set; }

        [JsonConstructor]
        public UserModel(string id, string firstName, string lastName, string displayName, string emailAddress, string password, string jobTitle, string collector, int trustpoints, bool hasAvailableItems, bool collectionRequested, List<NonFoodItemModel> nonFoodItemsAvailable, List<FoodItems> foodItemsAvailable, List<MessageModel> messages)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DisplayName = displayName;
            EmailAddress = emailAddress;
            Password = password;
            JobTitle = jobTitle;
            Collector = collector;
            Trustpoints = trustpoints;
            HasAvailableItems = hasAvailableItems;
            CollectionRequested = collectionRequested;
            NonFoodItemsAvailable = nonFoodItemsAvailable;
            FoodItemsAvailable = foodItemsAvailable;
            Messages = messages;
        }

        public UserModel(string firstName, string surname, string displayname, string email, string password)
        {
            
            FirstName = firstName;
            LastName= surname;
            DisplayName = displayname;
            EmailAddress = email;
            Password = password;
            Messages = new List<MessageModel>();
            FoodItemsAvailable = new List<FoodItems>();
            NonFoodItemsAvailable = new List<NonFoodItemModel>();
            CollectionRequested = false;
            HasAvailableItems = false;
            Trustpoints = 0;
            Collector = "";
            JobTitle = "";
        }
    }
}
