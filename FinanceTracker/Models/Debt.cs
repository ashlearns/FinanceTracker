namespace FinanceTracker.Models
{
   
    public enum DebtStatus
    {
        // Debt is currently active and being paid
        Active,

        // Debt is recorded but not yet actively being paid
        Pending,

        // Debt has passed its due date and is overdue
        OverDue
    }

    public class Debt
    {
        // Unique identifier for the debt
        public Guid DebtID { get; set; }

        // ID of the user who owns this debt entry
        public Guid UserId { get; set; }

        // Title  of the debt 
        public string Title { get; set; } = string.Empty;

        // Total amount of the debt when first created
        public decimal TotalAmount { get; set; }

        // Remaining amount left to be paid
        public decimal RemainingAmount { get; set; }

        // Most recent payment or transaction related to the debt
        public decimal LatestAmount { get; set; }

        //when it's supposed to be paid off
        public DateTime? EndDate { get; set; }

        // source of the debt
        public string? Source { get; set; }

        //  notes about the debt
        public string? Notes { get; set; }

        // Current status of the debt
        public DebtStatus Status { get; set; }
    }
}
