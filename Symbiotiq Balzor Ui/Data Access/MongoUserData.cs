using Blazorise;
using MongoDB.Driver;
using Symbiotiq_Balzor_Ui.Models;
using Symbiotiq_Balzor_Ui.MongoDB;

namespace Symbiotiq_Balzor_Ui.Data_Access
{
    public class MongoUserData : IMongoUserData
    {
        private readonly IMongoCollection<UserModel> _users;
        public MongoUserData(IDbConnection db)
        {
            _users = db.UserCollection;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var results = await _users.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<UserModel>> GetAllShops()
        {
            var results = await _users.FindAsync(u => u.JobTitle == "Shop");
            return results.ToList();
        }

        public async Task<UserModel> GetUser(string id)
        {
            var result = await _users.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var result = await _users.FindAsync(u => u.EmailAddress == email);
            return result.FirstOrDefault();
        }

        public async Task<UserModel> GetUserById(string id)
        {
            var result = await _users.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return _users.InsertOneAsync(user);
        }

        public async Task<List<MessageModel>> GetMessages(string id)
        {
            var user = await GetUser(id);
            if (user != null)
            {
                return user.Messages;
            }
            else
            {
                return new List<MessageModel>();
            }
        }

        public Task UpdateUSer(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }


    }
}
