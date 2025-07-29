using FinanceTracker.Helpers;
using FinanceTracker.Models;

namespace FinanceTracker.Services;


public class TagService : ITagService
{
    // File where tags are stored
    private const string FileName = "tags.json";

    
    private List<Tag> _tags = new();

    // Constructor: Loads tags from file or initializes default tags if no data exists
    public TagService()
    {
        Task.Run(async () =>
        {
            var data = await JsonStorageHelper.LoadFromFileAsync<List<Tag>>(FileName);

            if (data != null)
                _tags = data;
            else
                _tags = Tag.DefaultTags;
        });
    }

    // Retrieves all tags associated with the specified user,
    
        public Task<List<Tag>> GetAllTagsAsync(Guid userId)
    {
        var result = _tags
            .Where(t => t.IsDefault || t.UserID == userId)
            .ToList();

        return Task.FromResult(result);
    }

    // Adds a new tag
    public async Task AddTagAsync(Tag tag)
    {
        _tags.Add(tag);
        await SaveAsync();
    }

    // Updates an existing user-defined tag and saves changes in storage
    public async Task UpdateTagAsync(Tag tag)
    {
        var existing = _tags.FirstOrDefault(t => t.TagID == tag.TagID && !t.IsDefault);
        if (existing != null)
        {
            existing.Name = tag.Name;
            existing.TagType = tag.TagType;
            await SaveAsync();
        }
    }

    // Optional: Deletes a user-defined tag by ID
    public async Task DeleteTagAsync(Guid tagId)
    {
        var tag = _tags.FirstOrDefault(t => t.TagID == tagId && !t.IsDefault);
        if (tag != null)
        {
            _tags.Remove(tag);
            await SaveAsync();
        }
    }

    // Saves the current in-memory tag list to the JSON file
    public async Task SaveAsync()
    {
        await JsonStorageHelper.SaveToFileAsync(FileName, _tags);
    }
}
