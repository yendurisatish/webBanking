using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    interface IAdminService
    {
        IList<AccountDetail> GetAccountDetail();
        IList<Deposits> GetDeposits();
        IList<Loans> GetLoans();
        void CreateAccount(CreateUser cu, ref string errorMessage);
        void ApproveLoans(int id);
        void ApproveDeposits(int id);
        void CloseAccount(Int64 accno);
        void UpdateAccount(CreateUser cu);
    }
}
