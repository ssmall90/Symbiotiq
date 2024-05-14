using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver;
using Symbiotiq_Balzor_Ui.Models;
using Symbiotiq_Balzor_Ui.MongoDB;
using System.Collections;

namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public class MongoFoodItemData : IMongoFoodItemData
    {
        private readonly IMongoCollection<FoodItems> _foodItems;

        public MongoFoodItemData(IDbConnection db)
        {
            _foodItems = db.FoodItemCollection;
        }

        public Task AddFoodItem(FoodItems foodItems)
        {
            return _foodItems.InsertOneAsync(foodItems);
        }

        public Task UpdateItem(FoodItems item)
        {
            var filter = Builders<FoodItems>.Filter.Eq("Id", item.Id);
            return _foodItems.ReplaceOneAsync(filter, item, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<List<FoodItems>> GetAllFoodItems()
        {
            var results = await _foodItems.FindAsync(i => i.ItemAvailable == true);
            return results.ToList();
        }

        public async Task<List<FoodItems>> FilterFoodItemsBasedOnPreference(string pFilterParameter)
        {
            var results = await _foodItems.FindAsync(i => i.itemIngredientIdentificationName.Contains(pFilterParameter));
            return results.ToList();
        }

        public async Task<List<FoodItems>> FilterFoodItemsBasedOnCollection(bool pFilterCollection)
        {
            var results = await _foodItems.FindAsync(i => i.ItemAvailable == pFilterCollection);
            return results.ToList();
        }

        public async Task<List<FoodItems>> FilterFoodItemsBasedOnClaim(bool pFilterCollection)
        {
            var results = await _foodItems.FindAsync(i => i.ItemAvailable == pFilterCollection);
            return results.ToList();
        }

        public async Task<FoodItems> GetItemById(string id)
        {

            var results = await GetAllFoodItems();
            FoodItems foodItems = results.Where(i => i.Id == id).FirstOrDefault()!;

            return foodItems;
        }

        public async Task RemoveItem(string id)
        {
            var filter = Builders<FoodItems>.Filter.Eq("Id", id); 
            await _foodItems.DeleteOneAsync(filter);
        }

        public async Task<bool> IsValid(string id)
        {
            List<FoodItems> foodItems;
            FoodItems item;

            foodItems = await GetAllFoodItems();
            item = foodItems.FirstOrDefault(i => i.Id == id)!;

            if (item is not null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
