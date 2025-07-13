namespace FinanceTracker.Models
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public List<string> Tags { get; set; } = new();
        public string Note { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        // Debt-specific
        public string? DebtSource { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCleared { get; set; } = false;
    }
}
