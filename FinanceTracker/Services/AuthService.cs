using FinanceTracker.Models;

namespace FinanceTracker.Services
{
   
    public class AuthService
    {
        // Holds the currently authenticated user, if any
        public User? CurrentUser { get; private set; }

        // Indicates whether a user is currently logged in
        public bool IsLoggedIn => CurrentUser != null;

        // Sets the specified user as the currently logged-in user
        public void Login(User user)
        {
            CurrentUser = user;
        }

        // Logs out the currently authenticated user
        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
