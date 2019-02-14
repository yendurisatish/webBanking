using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
   public class Loans
    {
       public Int32 LoanId { get; set; }
       public Int64 AccountNumber { get; set; }
       public float LoanAmount { get; set; }
       public DateTime? ApprovedTime { get; set; }
       public string Approval { get; set; }
    }
}
