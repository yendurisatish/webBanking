using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
   public class ApproveLoans
    {
        public Int32 Id { get; set; }
        public Int64 AccountNumber { get; set; }
        public string LoanType { get; set; }
        public string Income { get; set; }
        public string LoanAmount { get; set; }
        public string EmpType { get; set; }
        public string City { get; set; }
        public string Approval { get; set; }
       // public string ApprovedTime { get; set; }
        public string Username { get; set; }
    }
}
