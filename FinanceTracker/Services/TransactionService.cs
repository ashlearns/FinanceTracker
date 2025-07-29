
using FinanceTracker.Helpers;
using FinanceTracker.Models;

namespace FinanceTracker.Services;


public class TransactionService : ITransactionService
{
    // File where transactions are stored locally in JSON format
    private const string FileName = "transactions.json";


    private List<Transaction> _transactions = new();

    // Constructor: Loads transactions from file on service initialization
    public TransactionService()
    {
        Task.Run(async () =>
        {
            var data = await JsonStorageHelper.LoadFromFileAsync<List<Transaction>>(FileName);
            if (data != null)
                _transactions = data;
        });
    }

    // Returns all transactions for a specific user, ordered by most recent
    public Task<List<Transaction>> GetTransactionsAsync(Guid userId)
    {
        var result = _transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.Date)
            .ToList();

        return Task.FromResult(result);
    }

    // Adds a new transaction after validating balance for debit types
    public async Task AddTransactionAsync(Transaction transaction)
    {
        // If it's a debit, ensure the user has enough balance
        if (transaction.Type == TransactionType.Debit)
        {
            var currentBalance = await GetCurrentBalanceAsync(transaction.UserId);
            if (transaction.Amount > currentBalance)
            {
                throw new InvalidOperationException(
                    $"Insufficient balance. Your current balance is {currentBalance:C}.");
            }
        }

        // Add the transaction and save to file
        _transactions.Add(transaction);
        await SaveTransactionsAsync();
    }

    // Updates an existing transaction by ID
    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        var existing = _transactions.FirstOrDefault(t => t.Id == transaction.Id);
        if (existing != null)
        {
            existing.Title = transaction.Title;
            existing.Amount = transaction.Amount;
            existing.Type = transaction.Type;
            existing.Tags = transaction.Tags;
            existing.Note = transaction.Note;
            existing.Date = transaction.Date;
            existing.DebtSource = transaction.DebtSource;
            existing.DueDate = transaction.DueDate;
            existing.IsCleared = transaction.IsCleared;

            await SaveTransactionsAsync();
        }
    }

    // Deletes a given transaction and updates the file
    public async Task DeleteTransactionAsync(Transaction transaction)
    {
        _transactions.Remove(transaction);
        await SaveTransactionsAsync();
    }

    // Helper method to save all transactions to the JSON file
    private async Task SaveTransactionsAsync()
    {
        await JsonStorageHelper.SaveToFileAsync(FileName, _transactions);
    }

    // Calculates and returns the user's current available balance
    public Task<decimal> GetCurrentBalanceAsync(Guid userId)
    {
        var transactions = _transactions
            .Where(t => t.UserId == userId)
            .ToList();

        // Sum of credit transactions
        decimal inflows = transactions
            .Where(t => t.Type == TransactionType.Credit)
            .Sum(t => t.Amount);

        // Sum of debit transactions
        decimal outflows = transactions
            .Where(t => t.Type == TransactionType.Debit)
            .Sum(t => t.Amount);

        // Sum of cleared debt transactions
        decimal clearedDebts = transactions
            .Where(t => t.Type == TransactionType.Debt && t.IsCleared)
            .Sum(t => t.Amount);

        // Final balance = credits + cleared debts - debits
        decimal balance = inflows + clearedDebts - outflows;

        return Task.FromResult(Math.Max(balance, 0)); // No negative balance
    }

    // Automatically clears pending debts if there is enough balance
    public async Task ClearPendingDebtsAsync(Guid userId)
    {
        var balance = await GetCurrentBalanceAsync(userId);

        // Get all uncleared debts sorted by date
        var pendingDebts = _transactions
            .Where(t => t.UserId == userId
                        && t.Type == TransactionType.Debt
                        && !t.IsCleared)
            .OrderBy(t => t.Date)
            .ToList();

        // Attempt to clear debts one by one if balance is sufficient
        foreach (var debt in pendingDebts)
        {
            if (balance >= debt.Amount)
            {
                debt.IsCleared = true;
                balance -= debt.Amount;
            }
        }

        await SaveTransactionsAsync();
    }
}
