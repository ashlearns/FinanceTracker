
namespace FinanceTracker.Models
{
   
    public enum TransactionType
    {
        // Money coming in (income, received funds, etc.)
        Credit,

        // Money going out (expenses, purchases, etc.)
        Debit,

        // Money owed or borrowed (to be paid later)
        Debt
    }
}
