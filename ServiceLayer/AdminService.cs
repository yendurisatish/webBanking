using ModelLayer;
using RepositoryLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AdminService : IAdminService
    {
        //this is 1st comment
        AdminRepository repo;
        public AdminService()
        {
            repo = new AdminRepository();
        }

        public IList<AccountDetail> GetAccountDetail()
        {
            DataSet ds = repo.GetAccountDetail();
            IList<AccountDetail> accountDetailList = new List<AccountDetail>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AccountDetail detail = new AccountDetail();
                detail.UserName = Convert.ToString(row["username"]);
                detail.AccountNumber = Convert.ToInt64(row["accountno"]);
                detail.FirstName = Convert.ToString(row["firstname"]);
                detail.LastName = Convert.ToString(row["lastname"]);
                detail.Dob = Convert.ToString(row["dob"]);
                detail.PhoneNumber = Convert.ToString(row["phoneno"]);
                detail.Email = Convert.ToString(row["email"]);
                detail.Aadhar = Convert.ToString(row["aadhar_no"]);
                detail.AccountType = Convert.ToString(row["account_type"]);
                detail.Balance = Convert.ToInt32(row["balance"]);
                detail.Address = Convert.ToString(row["address"]);
                detail.IsAdmin = Convert.ToBoolean(row["admin"]);
                accountDetailList.Add(detail);
            }
            return accountDetailList;
        }

        public IList<Deposits> GetDeposits()
        {
            DataSet ds = repo.GetDeposits();
            IList<Deposits> depositsList = new List<Deposits>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Deposits dep = new Deposits();
                dep.DepositId = Convert.ToInt32(row["deposit_id"]);
                dep.AccountNumber = Convert.ToInt64(row["accountno"]);
                dep.DepositAmount = Convert.ToInt32(row["deposit_amount"]);
                dep.Duration = Convert.ToInt32(row["duration"]);
                dep.DepositTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                dep.Approved = Convert.ToString(row["approved"]);
                depositsList.Add(dep);
            }

            return depositsList;

        }
        public IList<Loans> GetLoans()
        {
            DataSet ds = repo.GetLoans();
            IList<Loans> loansList = new List<Loans>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Loans loan = new Loans();
                loan.LoanId = Convert.ToInt32(row["loan_id"]);
                loan.AccountNumber = Convert.ToInt64(row["account_no"]);
                loan.LoanAmount = Convert.ToInt32(row["loan_amount"]);
                loan.ApprovedTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                loan.Approval = Convert.ToString(row["approved"]);

                loansList.Add(loan);
            }

            return loansList;

        }
        
        public void ApproveLoans(int id,int acc)
        {
            repo.ApproveLoans(id,acc);
        }
        public void ApproveDeposits(int id, int acc)
        {
            repo.ApproveDeposits(id,acc);
        }
        public void CloseAccount(Int64 accno)
        {
            repo.CloseAccount(accno);
        }
        public void UpdateAccount(CreateUser cu)
        {
            repo.UpdateAccount(cu);
        }


        IList<AccountDetail> IAdminService.GetAccountDetail()
        {
            throw new NotImplementedException();
        }

        IList<Deposits> IAdminService.GetDeposits()
        {
            throw new NotImplementedException();
        }

        IList<Loans> IAdminService.GetLoans()
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(CreateUser cu, ref string errorMessage)
        {
            repo.CreateAccount(cu, ref errorMessage);
        }

        void IAdminService.ApproveLoans(int id)
        {
            throw new NotImplementedException();
        }

        void IAdminService.ApproveDeposits(int id)
        {
            throw new NotImplementedException();
        }

        void IAdminService.CloseAccount(long accno)
        {
            throw new NotImplementedException();
        }

        void IAdminService.UpdateAccount(CreateUser cu)
        {
            throw new NotImplementedException();
        }
    }
}
