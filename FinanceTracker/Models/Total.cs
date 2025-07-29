
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinanceTracker.Models
{

    public class Totals
    {
        // Unique identifier of the user
        public Guid UserID { get; set; }

        // The user's previous balance before current transactions
        public decimal OldBalance { get; set; } = 0;

        // Total amount of money received 
        public decimal CashIn { get; set; } = 0;

        // Total amount of money spent
        public decimal CashOut { get; set; } = 0;

        
        // Formula: OldBalance + CashIn - CashOut
        public decimal NewBalance => OldBalance + CashIn - CashOut;

        
        public decimal TotalAmount { get; set; } = 0;
    }
}
