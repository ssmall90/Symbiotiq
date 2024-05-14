using Symbiotiq_Balzor_Ui.Models;

namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public interface IMongoFoodItemData
    {
        Task AddFoodItem(FoodItems foodItems);
        Task UpdateItem(FoodItems item);
        Task<List<FoodItems>> FilterFoodItemsBasedOnClaim(bool pFilterCollection);
        Task<List<FoodItems>> FilterFoodItemsBasedOnCollection(bool pFilterCollection);
        Task<List<FoodItems>> FilterFoodItemsBasedOnPreference(string pFilterParameter);
        Task<List<FoodItems>> GetAllFoodItems();
        Task<FoodItems> GetItemById(string id);
        Task RemoveItem(string id);
        Task<bool> IsValid(string id);
    }
}