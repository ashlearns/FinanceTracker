using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    public interface IUserService
    {
        // Gets the currently active or logged in user
        Task<User?> GetCurrentUserAsync();

        // Saves a new user or updates an existing user
        Task SaveUserAsync(User user);

        // Retrieves a specific user by their unique ID
        Task<User?> GetUserByIdAsync(Guid userId);

        // Deletes a user from the system by ID
        Task DeleteUserAsync(Guid userId);

        // Returns a list of all users
        Task<List<User>> GetAllUsersAsync();

        // Sets a specific user as the current active user
        Task SetCurrentUserAsync(Guid userId);
    }
}
