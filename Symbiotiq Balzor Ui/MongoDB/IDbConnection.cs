using MongoDB.Driver;
using Symbiotiq_Balzor_Ui.Models;

namespace Symbiotiq_Balzor_Ui.MongoDB
{
    public interface IDbConnection
    {
        string CategoryCollectionName { get; }
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<FoodItems> FoodItemCollection { get; }
        string FoodItemCollectionName { get; }
        IMongoCollection<NonFoodItemModel> NonFoodItemCollection { get; }
        string NonFoodItemCollectionName { get; }
        IMongoCollection<ShopModel> ShopCollection { get; }
        string ShopCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
    }
}