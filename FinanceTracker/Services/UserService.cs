
using FinanceTracker.Helpers;
using FinanceTracker.Models;

namespace FinanceTracker.Services
{

    public class UserService : IUserService
    {
        // File where user data will be saved/loaded from
        private const string FileName = "users.json";

        // In-memory list of all users
        private List<User> _users = new();

        // The currently active (logged-in) user
        private User? _currentUser;

        // Constructor: Loads users from file and sets current user if available
        public UserService()
        {
            Task.Run(async () =>
            {
                // Load the users from the JSON file
                var loaded = await JsonStorageHelper.LoadFromFileAsync<List<User>>(FileName);

                // If any users were loaded, assign them to the internal list
                if (loaded != null)
                {
                    _users = loaded;
                }

                // Automatically set the first user as the current user (if not already set)
                if (_currentUser == null && _users.Any())
                {
                    _currentUser = _users.First();
                }
            });
        }

        // Returns the current user (fallbacks to first user if current is null)
        public Task<User?> GetCurrentUserAsync()
        {
            if (_currentUser == null && _users.Any())
                _currentUser = _users.First();

            return Task.FromResult(_currentUser);
        }

        // Adds or updates a user, then saves the entire list to file
        public async Task SaveUserAsync(User user)
        {
            // Try to find if this user already exists (by ID)
            var existing = _users.FirstOrDefault(u => u.UserId == user.UserId);

            if (existing == null)
            {
                // New user: assign a new ID and add to the list
                user.UserId = Guid.NewGuid();
                _users.Add(user);
            }
            else
            {
                // Existing user: update values
                existing.Username = user.Username;
                existing.Password = user.Password;
                existing.PreferredCurrency = user.PreferredCurrency;
            }

            // Set this user as the current user
            _currentUser = user;

            // Save to file
            await JsonStorageHelper.SaveToFileAsync(FileName, _users);
        }

        // Gets a user by their unique ID
        public Task<User?> GetUserByIdAsync(Guid userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            return Task.FromResult(user);
        }

        // Deletes a user and updates the file; resets current user if needed
        public async Task DeleteUserAsync(Guid userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _users.Remove(user);
                await JsonStorageHelper.SaveToFileAsync(FileName, _users);

                // If the deleted user was the current one, clear it
                if (_currentUser?.UserId == userId)
                {
                    _currentUser = null;
                }
            }
        }

        // Returns all users currently stored
        public Task<List<User>> GetAllUsersAsync()
        {
            return Task.FromResult(_users);
        }

        // Sets a specific user as the current user
        public Task SetCurrentUserAsync(Guid userId)
        {
            _currentUser = _users.FirstOrDefault(u => u.UserId == userId);
            return Task.CompletedTask;
        }
    }
}
