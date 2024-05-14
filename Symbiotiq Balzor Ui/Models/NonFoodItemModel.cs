using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Symbiotiq_Balzor_Ui.Models
{
    public class NonFoodItemModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ItemDonater { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public DateTime CollectionTime { get; set; }
        public string ItemCollectionPoint { get; set; }
        public string ItemCategory { get; set; }
        public string PathToItemImage { get; set; }
        public bool ItemAvailable { get; set; }

        public NonFoodItemModel()
        {
            ItemAvailable = true;
        }

    }
}
