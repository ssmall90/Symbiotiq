using Symbiotiq_Balzor_Ui.Models;

namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public interface IMongoNonFoodItemData
    {
        Task CreateNonFoodItem(NonFoodItemModel item);
        Task UpdateItem(NonFoodItemModel item);
        Task<List<NonFoodItemModel>> FilterNonFoodItems(string category);
        Task<List<NonFoodItemModel>> GetAllAvailableNonFoodItems();
        Task<List<NonFoodItemModel>> GetAllNonFoodItems();
        Task<NonFoodItemModel> GetItemById(string id);
        Task RemoveItem(string id);
        Task<bool> IsValid(string id);
    }
}