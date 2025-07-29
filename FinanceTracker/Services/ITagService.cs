using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    // Interface defining the contract for tag-related operations
    public interface ITagService
    {
        // Retrieves all tags associated with a specific user
        Task<List<Tag>> GetAllTagsAsync(Guid userId);

        // Adds a new tag to the user's transaction
        Task AddTagAsync(Tag tag);

        // Updates an existing user-defined tag
        Task UpdateTagAsync(Tag tag);

        // save tag
        Task SaveAsync();
    }
}
