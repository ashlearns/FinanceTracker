namespace FinanceTracker.Models;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PreferredCurrency { get; set; } = "USD";
}
