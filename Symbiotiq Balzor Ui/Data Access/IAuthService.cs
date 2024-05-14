using Symbiotiq_Balzor_Ui.Models;

namespace Symbiotiq_Balzor_Ui
{
    public interface IAuthService
    {
        UserModel CurrentUser { get; }
        bool IsAuthenticated { get; }
        event Action OnAuthenticationChanged;
        Task<UserModel?> GetCurrentUser(string id);
        Task InitializeAsync();
        Task LoadUserFromStorage();
        Task<bool> Login(string email, string password);
        void Logout();
        void NotifyAuthenticationChanged();
        void SaveUserToStorage(UserModel user);
    }
}