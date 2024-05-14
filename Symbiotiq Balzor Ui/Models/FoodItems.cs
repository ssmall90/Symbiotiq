using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography.Xml;

namespace Symbiotiq_Balzor_Ui.Models
{
    public class FoodItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ItemDonater { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCollectionPoint { get; set; }
        public int Quantity { get; set; }
        public DateTime CollectionTime { get; set; }
        public List<string> ItemCategory { get; set; }

        public string PathToItemImage { get; set; }
        public bool ItemAvailable { get; set; }
        public List<string> itemIngredientIdentificationName { get; set; }
        public DateTime datePostAdded = DateTime.Now.Date;
        public DateTime usedByDate;

        public FoodItems()
        {
            ItemAvailable = true;
        }
        public bool ExpirationDatePast()
        {
            int dateCompare = DateTime.Compare(usedByDate, DateTime.Now);
            if (dateCompare > 0) { return false; } else { return true; }
        }
        public bool postDurationDayPast(int pPostNumberOfDays, int pPostDurationDate)
        {
            TimeSpan dateDifference = datePostAdded.Subtract(DateTime.Now);
            int days = dateDifference.Days;

            if (pPostNumberOfDays == days) { } else { pPostNumberOfDays = days; }
            if (pPostNumberOfDays >= pPostDurationDate) { return true; } else { return false; }
        }

    }



}
