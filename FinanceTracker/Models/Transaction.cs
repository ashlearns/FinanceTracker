
namespace FinanceTracker.Models
{
    
    public class Transaction
    {
        // Unique identifier for the transaction 
        public Guid Id { get; set; } = Guid.NewGuid();

        // ID of the user who owns this transaction(FK)
        public Guid UserId { get; set; }

        //  name of the transaction
        public string Title { get; set; } = string.Empty;

        // Amount
        public decimal Amount { get; set; }

        // Type of transaction: Credit, Debit, or Debt;taken from transaction type
        public TransactionType Type { get; set; }

        // List of tags/labels to categorize the transaction 
        public List<string> Tags { get; set; } = new();

        // add notes
        public string? Note { get; set; }

        // transaction date
        public DateTime Date { get; set; }

        //  source of the debt
        public string? DebtSource { get; set; }

        // due date of debts
        public DateTime? DueDate { get; set; }

        // when was debt cleared off?
        public bool IsCleared { get; set; } = false;
    }
}
