using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
   public class ApproveDeposit
    {
        public Int32 DepositId { get; set; }
        public Int64 AccountNumber { get; set; }
        public float DepositAmount { get; set; }
        public Int32 Duration { get; set; }
       // public DateTime? DepositTime { get; set; }
        public string Approved { get; set; }
    }
}
