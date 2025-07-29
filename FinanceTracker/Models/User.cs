namespace FinanceTracker.Models
{
    public class User
    {
        // Unique identifier for the user
        public Guid UserId { get; set; } = Guid.NewGuid();

        // Username of the user 
        public string Username { get; set; } = string.Empty;

        // Password of the user
        public string Password { get; set; } = string.Empty;

        // Preferred currency of the user 
        public string PreferredCurrency { get; set; } = "USD";
    }
}
