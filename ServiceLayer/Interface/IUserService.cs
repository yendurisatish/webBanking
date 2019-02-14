using System;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    interface IUserService
    {
        AccountDetail  getUserDetails(Int64 accno);
        AccountDetail Login(string username, string password);
        void sendMoney(Transaction ts);
        void applyLoan(ApplyLoan ls);
        void applyDeposit(Deposits ds);
       IList <Transaction> transHistory(Int64 accno);
       IList<Loans> loanDetails(Int64 accno);
       IList<Deposits> depositDetails(Int64 accno);
    }
}
