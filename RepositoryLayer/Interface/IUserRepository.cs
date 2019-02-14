using System;
using ModelLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    interface IUserRepository
    {
        DataSet getUserDetails(Int64 accno);
        void sendMoney(Transaction ts);
        DataSet transHistory(Int64 accno);
        DataSet loanDetails(Int64 accno);
        DataSet depositDetails(Int64 accno);
        void applyLoan(ApplyLoan ls);
        void applyDeposit(Deposits ds);
        DataSet Login(string username, string password);
    }
}
