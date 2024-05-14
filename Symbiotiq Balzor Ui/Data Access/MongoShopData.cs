using MongoDB.Driver;
using Symbiotiq_Balzor_Ui.Models;


namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public class MongoShopData : IMongoShopData
    {
        private readonly IMongoCollection<ShopModel> _shops;

        public MongoShopData(MongoDB.IDbConnection db)
        {
            _shops = db.ShopCollection;
        }

        public async Task<List<ShopModel>> GetAllShopsAsync()
        {
            var result = await _shops.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<List<ShopModel>> GetShopsAwaitingCollection()
        {
            var results = await _shops.FindAsync(s => s.ItemsAvailable == true);
            return results.ToList();
        }

        public Task CreateShop(ShopModel shop)
        {
            return _shops.InsertOneAsync(shop);
        }

    }
}
