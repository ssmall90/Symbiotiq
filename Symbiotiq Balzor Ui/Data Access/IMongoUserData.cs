using Symbiotiq_Balzor_Ui.Models;

namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public interface IMongoUserData
    {
        Task CreateUser(UserModel user);
        Task<List<UserModel>> GetAllShops();
        Task<List<UserModel>> GetAllUsers();
        Task<List<MessageModel>> GetMessages(string id);
        Task<UserModel> GetUser(string id);
        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> GetUserById(string id);
        Task UpdateUSer(UserModel user);
    }
}