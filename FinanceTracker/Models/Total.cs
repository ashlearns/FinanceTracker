using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    public class Totals
    {
        public Guid UserID { get; set; }
        public decimal OldBalance { get; set; } = 0;
        public decimal CashIn { get; set; } = 0;
        public decimal CashOut { get; set; } = 0;

    
        public decimal NewBalance => OldBalance + CashIn - CashOut;

        public decimal TotalAmount { get; set; } = 0; 
    }

}
