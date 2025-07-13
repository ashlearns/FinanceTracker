namespace FinanceTracker.Models;

public class Tag
{
    public Guid UserID { get; set; } = Guid.Empty;
    public Guid TagID { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public string TagType { get; set; } = string.Empty;

    public static List<Tag> DefaultTags => new List<Tag>
    {
        new Tag { Name = "Yearly", IsDefault = true, TagType = "Frequency" },
        new Tag { Name = "Monthly", IsDefault = true, TagType = "Frequency" },
        new Tag { Name = "Food", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Drinks", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Clothes", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Gadgets", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Miscellaneous", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Fuel", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Rent", IsDefault = true, TagType = "Category" },
        new Tag { Name = "EMI", IsDefault = true, TagType = "Category" },
        new Tag { Name = "Party", IsDefault = true, TagType = "Category" }
    };
}
