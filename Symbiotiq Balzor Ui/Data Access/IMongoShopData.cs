using Symbiotiq_Balzor_Ui.Models;

namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public interface IMongoShopData
    {
        Task CreateShop(ShopModel shop);
        Task<List<ShopModel>> GetAllShopsAsync();
        Task<List<ShopModel>> GetShopsAwaitingCollection();
    }
}