using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Symbiotiq_Balzor_Ui.Models
{
    public class ShopModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ShopName { get; set; }
        public bool ItemsAvailable { get; set; }
        public bool CollectionArranged { get; set; }


    }
}
