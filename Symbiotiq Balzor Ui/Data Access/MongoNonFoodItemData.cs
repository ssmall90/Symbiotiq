using MongoDB.Driver;
using Symbiotiq_Balzor_Ui.Models;
using Symbiotiq_Balzor_Ui.MongoDB;


namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public class MongoNonFoodItemData : IMongoNonFoodItemData
    {
        private readonly IMongoCollection<NonFoodItemModel> _nonFoodItems;

        public MongoNonFoodItemData(IDbConnection db)
        {
            _nonFoodItems = db.NonFoodItemCollection;
        }

        public async Task<List<NonFoodItemModel>> GetAllNonFoodItems()
        {
            var result = await _nonFoodItems.FindAsync(i => i.ItemAvailable == true);
            return result.ToList();
        }

        public Task UpdateItem(NonFoodItemModel item)
        {
            var filter = Builders<NonFoodItemModel>.Filter.Eq("Id", item.Id);
            return _nonFoodItems.ReplaceOneAsync(filter, item, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<List<NonFoodItemModel>> GetAllAvailableNonFoodItems()
        {
            var result = await _nonFoodItems.FindAsync(i => i.ItemAvailable == true);
            return result.ToList();
        }

        public async Task<List<NonFoodItemModel>> FilterNonFoodItems(string category)
        {
            var result = await _nonFoodItems.FindAsync(i => i.ItemCategory.Contains(category));
            return result.ToList();
        }

        public Task CreateNonFoodItem(NonFoodItemModel item)
        {
            return _nonFoodItems.InsertOneAsync(item);
        }

        public async Task<NonFoodItemModel> GetItemById(string id)
        {

            var results = await GetAllNonFoodItems();
            NonFoodItemModel nonFoodItems = results.Where(i => i.Id == id).FirstOrDefault()!;

            return nonFoodItems;
        }
        public async Task RemoveItem(string id)
        {
            var filter = Builders<NonFoodItemModel>.Filter.Eq("Id", id);
            await _nonFoodItems.DeleteOneAsync(filter);
        }

        public async Task<bool> IsValid(string id)
        {
            if (_nonFoodItems.FindAsync(i => i.Id == id) == null)
            { return false; }
            return true;
        }

    }
}
