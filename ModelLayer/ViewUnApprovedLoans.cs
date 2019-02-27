using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
  public  class ViewUnApprovedLoans
    {
        public Int32 LoanId { get; set; }
        public string Username { get; set; }
        public string LoanType { get; set; }
        public string Income { get; set; }
        public Int64 AccountNumber { get; set; }
        public string LoanAmount { get; set; }
        public string Payslip { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public string Approval { get; set; }


    }
}
