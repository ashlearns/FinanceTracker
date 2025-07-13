using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    public enum DebtStatus
    {
        Active,
        Pending,
        OverDue
    }

    public class Debt
    {
        public Guid DebtID { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal LatestAmount { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Source { get; set; }
        public string? Notes { get; set; }
        public DebtStatus Status { get; set; }
    }

}

