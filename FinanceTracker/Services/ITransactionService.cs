using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    
    public interface ITransactionService
    {
        // Retrieves all transactions associated with a specific user
        Task<List<Transaction>> GetTransactionsAsync(Guid userId);

        // Adds a new transaction for the specified user
        Task AddTransactionAsync(Transaction transaction);

        // Updates the details of an existing transaction
        Task UpdateTransactionAsync(Transaction transaction);

        // Deletes a transaction from the user's transaction list
        Task DeleteTransactionAsync(Transaction transaction);

        // Calculates and returns the current balance for a specific user
        Task<decimal> GetCurrentBalanceAsync(Guid userId);

        // Automatically clears all pending debts, used when seeing within balance
        Task ClearPendingDebtsAsync(Guid userId);
    }
}
