using Symbiotiq_Balzor_Ui.Data_Access;
using Symbiotiq_Balzor_Ui.Models;
using Symbiotiq_Balzor_Ui.MongoDB;
using System.Text.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Symbiotiq_Balzor_Ui
{
    public class AuthService : IAuthService
    {
        private const string UserKey = "currentUser";

        private readonly IJSRuntime _jsRuntime;

        private UserModel? _currentUser;

        private readonly IMongoUserData _userData;

        public event Action OnAuthenticationChanged;

        public bool IsAuthenticated => _currentUser != null;

        public UserModel CurrentUser => _currentUser;


        public AuthService(IMongoUserData userData, IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _userData = userData;

        }

        public async Task InitializeAsync()
        {
            await LoadUserFromStorage();
        }

        public async Task<UserModel?> GetCurrentUser(string id)
        {
            var result = await _userData.GetUserById(id);
            if (result is not null)
            {
                _currentUser = result;
                return _currentUser;
            }
            else
            {
                return null;
            }

        }

        public async Task LoadUserFromStorage()
        {
            var userJson = await _jsRuntime.InvokeAsync<string>("blazorSessionStorage.getItem", UserKey);
            if (userJson != null)
            {
                _currentUser = JsonSerializer.Deserialize<UserModel>(userJson);
                NotifyAuthenticationChanged();
            }
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _userData.GetUserByEmail(email);

            if (user != null && user.Password == password)
            {
                _currentUser = user;
                SaveUserToStorage(_currentUser);
                NotifyAuthenticationChanged();
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Logout()
        {
            _currentUser = null;
            _jsRuntime.InvokeVoidAsync("blazorSessionStorage.removeItem", UserKey);
            NotifyAuthenticationChanged();

        }

        public void SaveUserToStorage(UserModel user)
        {
            var userJson = JsonSerializer.Serialize(user);
            _jsRuntime.InvokeVoidAsync("blazorSessionStorage.setItem", UserKey, userJson);
        }

        public void NotifyAuthenticationChanged()
        {
            OnAuthenticationChanged?.Invoke();
        }

    }
}
