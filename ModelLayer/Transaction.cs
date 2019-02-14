using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Transaction
    {
       public Int64 senderaccount { get; set; }
       public Int64 targetaccount{ get; set; }
       public float balance { get; set; }
       public int id { get; set; }
       public DateTime time { get; set; }
    }
}
