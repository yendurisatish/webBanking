using System;
using ModelLayer;
using RepositoryLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ServiceLayer
{
   public class UserService
    {
        UserRepository repo;
        public UserService()
        {
            repo = new UserRepository();
        }
       public IList< Transaction> transHistory(Int64 accno)
        {
            DataSet ds = repo.transHistory(accno);
             IList<Transaction> transList = new List<Transaction>();
             foreach (DataRow row in ds.Tables[0].Rows)
             {
                 Transaction detail = new Transaction();
                 detail.id = Convert.ToInt32(row["transid"]);
                 detail.balance = Convert.ToInt32(row["amount"]);
                 detail.senderaccount = Convert.ToInt64(row["trans_account"]);
                 detail.targetaccount = Convert.ToInt64(row["oth_account"]);
                 detail.time = Convert.ToDateTime(row["time"]);
                 transList.Add(detail);
             }
             return transList;
        }

       public IList<Loans> loanDetails(Int64 accno)
       {
           DataSet ds = repo.loanDetails(accno);
           IList<Loans> loanlist = new List<Loans>();
           foreach (DataRow row in ds.Tables[0].Rows)
           {
               Loans detail = new Loans();
               detail.AccountNumber = Convert.ToInt64(row["account_no"]);
               detail.LoanId = Convert.ToInt32(row["loan_id"]);
               detail.Approval = Convert.ToString(row["approved"]);
               detail.ApprovedTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
               detail.LoanAmount = Convert.ToInt32(row["loan_amount"]);
               loanlist.Add(detail);
           }
           return loanlist;
       }
       public IList<Deposits> depositDetails(Int64 accno)
       {
           DataSet ds = repo.depositDetails(accno);
           IList<Deposits> depositlist = new List<Deposits>();
           foreach (DataRow row in ds.Tables[0].Rows)
           {
               Deposits detail = new Deposits();
               detail.AccountNumber = Convert.ToInt64(row["accountno"]);
               detail.DepositId = Convert.ToInt32(row["deposit_id"]);
               detail.Approved = Convert.ToString(row["approved"]);
               detail.DepositTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
               detail.DepositAmount = Convert.ToInt32(row["deposit_amount"]);
               detail.Duration = Convert.ToInt32(row["duration"]);
               depositlist.Add(detail);
           }
           return depositlist;
       }

        public AccountDetail getUserDetails(Int64 accno)
        {
            DataSet ds = repo.getUserDetails(accno);
            AccountDetail detail = new AccountDetail();
           
            detail.UserName = Convert.ToString(ds.Tables[0].Rows[0]["username"]);
            detail.AccountNumber = Convert.ToInt64(ds.Tables[0].Rows[0]["accountno"]);
            detail.FirstName = Convert.ToString(ds.Tables[0].Rows[0]["firstname"]);
            detail.LastName = Convert.ToString(ds.Tables[0].Rows[0]["lastname"]);
            detail.Dob = Convert.ToString(ds.Tables[0].Rows[0]["dob"]);
            detail.PhoneNumber = Convert.ToString(ds.Tables[0].Rows[0]["phoneno"]);
            detail.Email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);
            detail.Aadhar = Convert.ToString(ds.Tables[0].Rows[0]["aadhar_no"]);
            detail.AccountType = Convert.ToString(ds.Tables[0].Rows[0]["account_type"]);
            detail.Balance = Convert.ToInt32(ds.Tables[0].Rows[0]["balance"]);
            detail.Address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
            detail.IsAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["admin"]);
            return detail;
        }



        public AccountDetail Login(string username,string password)
        {
            DataSet ds = repo.Login(username,password);
            AccountDetail detail = new AccountDetail();

            detail.UserName = Convert.ToString(ds.Tables[0].Rows[0]["username"]);
            detail.AccountNumber = Convert.ToInt64(ds.Tables[0].Rows[0]["accountno"]);
            detail.FirstName = Convert.ToString(ds.Tables[0].Rows[0]["firstname"]);
            detail.LastName = Convert.ToString(ds.Tables[0].Rows[0]["lastname"]);
            detail.Dob = Convert.ToString(ds.Tables[0].Rows[0]["dob"]);
            detail.PhoneNumber = Convert.ToString(ds.Tables[0].Rows[0]["phoneno"]);
            detail.Email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);
            detail.Aadhar = Convert.ToString(ds.Tables[0].Rows[0]["aadhar_no"]);
            detail.AccountType = Convert.ToString(ds.Tables[0].Rows[0]["account_type"]);
            detail.Balance = Convert.ToInt32(ds.Tables[0].Rows[0]["balance"]);
            detail.Address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
            detail.IsAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["admin"]);
            return detail;
        }
       public void applyLoan(ApplyLoan ls)
        {
            repo.applyLoan(ls);
        }
       public void applyDeposit(Deposits ds)
       {
           repo.applyDeposit(ds);
       }
        public void sendMoney(Transaction ts)
        {
            repo.sendMoney(ts) ;
        }
    }
}
