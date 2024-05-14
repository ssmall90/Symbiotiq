using MongoDB.Driver;
using Symbiotiq_Balzor_Ui.Models;
using System.Data;

namespace Symbiotiq_Balzor_Ui.MongoDB
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";
        public string DbName { get; private set; }
        public string CategoryCollectionName { get; private set; } = "categories";
        public string UserCollectionName { get; private set; } = "users";
        public string ShopCollectionName { get; private set; } = "shops";
        public string NonFoodItemCollectionName { get; private set; } = "non-food_items";
        public string FoodItemCollectionName { get; private set; } = "food_items";

        public MongoClient Client { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }
        public IMongoCollection<ShopModel> ShopCollection { get; private set; }
        public IMongoCollection<NonFoodItemModel> NonFoodItemCollection { get; private set; }
        public IMongoCollection<FoodItems> FoodItemCollection { get; private set; }



        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

            UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
            ShopCollection = _db.GetCollection<ShopModel>(ShopCollectionName);
            NonFoodItemCollection = _db.GetCollection<NonFoodItemModel>(NonFoodItemCollectionName);
            FoodItemCollection = _db.GetCollection<FoodItems>(FoodItemCollectionName);
        }
    }
}
