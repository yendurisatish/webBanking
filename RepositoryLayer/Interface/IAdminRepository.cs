using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    interface IAdminRepository
    {
        DataSet GetAccountDetail();
        DataSet GetDeposits();
        DataSet GetLoans();
        void ApproveLoans(int id);
        void ApproveDeposits(int id);
        void CloseAccount(Int64 acc);
        void CreateAccount(CreateUser cu,ref string errormessage);
        void UpdateAccount(CreateUser cu);
    }
}
