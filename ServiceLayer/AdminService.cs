﻿using ModelLayer;
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
                detail.IsAdmin = Convert.ToString(row["admin"]);
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
        public IList<ApproveDeposit> GetUnApprovedDeposits()
        {
            DataSet ds = repo.GetUnApprovedDeposits();
            IList<ApproveDeposit> depositsList = new List<ApproveDeposit>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ApproveDeposit dep = new ApproveDeposit();
                dep.DepositId = Convert.ToInt32(row["deposit_id"]);
                dep.AccountNumber = Convert.ToInt64(row["accountno"]);
                dep.DepositAmount = Convert.ToInt32(row["deposit_amount"]);
                dep.Duration = Convert.ToInt32(row["duration"]);
               // dep.DepositTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                dep.Approved = Convert.ToString(row["approved"]);
                depositsList.Add(dep);
            }

            return depositsList;

        }
        public IList<AdminViewLoans> GetLoans()
        {
            DataSet ds = repo.GetLoans();
            IList<AdminViewLoans> loansList = new List<AdminViewLoans>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AdminViewLoans detail = new AdminViewLoans();
                detail.AccountNumber = Convert.ToInt64(row["account_no"]);
                detail.Id = Convert.ToInt32(row["Id"]);
                detail.Username = Convert.ToString(row["username"]);
                detail.Approval = Convert.ToString(row["approved"]);
                detail.ApprovedTime = Convert.ToString(row["approved_time"]);
                //detail.ApprovedTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                detail.LoanAmount = Convert.ToString(row["loan_amount"]);
                detail.City = Convert.ToString(row["city"]);
                detail.EmpType = Convert.ToString(row["Emp_Type"]);
                detail.LoanType = Convert.ToString(row["LoanType"]);
                detail.Income = Convert.ToString(row["Income"]);

                loansList.Add(detail);
            }

            return loansList;

        }
        public IList<AdminViewLoans> VerifierViewLoans()
        {
            DataSet ds = repo.VerifierGetLoans();
            IList<AdminViewLoans> loansList = new List<AdminViewLoans>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AdminViewLoans detail = new AdminViewLoans();
                detail.AccountNumber = Convert.ToInt64(row["account_no"]);
                detail.Id = Convert.ToInt32(row["Id"]);
                detail.Username = Convert.ToString(row["username"]);
              //  detail.Approval = Convert.ToString(row["approved"]);
               // detail.ApprovedTime = Convert.ToString(row["approved_time"]);
                //detail.ApprovedTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                detail.LoanAmount = Convert.ToString(row["loan_amount"]);
               // detail.City = Convert.ToString(row["city"]);
                //detail.EmpType = Convert.ToString(row["Emp_Type"]);
                detail.LoanType = Convert.ToString(row["LoanType"]);
                detail.Income = Convert.ToString(row["Income"]);
                detail.status = Convert.ToString(row["status"]);

                loansList.Add(detail);
            }

            return loansList;

        }
        public AdminViewLoans VerifierViewLoans(int id)
        {
            DataSet ds = repo.VerifierGetLoans(id);
           // AdminViewLoans loansList = new AdminViewLoans();
            
                AdminViewLoans detail = new AdminViewLoans();
                
                detail.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                detail.Username = Convert.ToString(ds.Tables[0].Rows[0]["username"]);
                //  detail.Approval = Convert.ToString(row["approved"]);
                // detail.ApprovedTime = Convert.ToString(row["approved_time"]);
                //detail.ApprovedTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                detail.AccountNumber = Convert.ToInt64(ds.Tables[0].Rows[0]["account_no"]);
                detail.LoanAmount = Convert.ToString(ds.Tables[0].Rows[0]["loan_amount"]);
                // detail.City = Convert.ToString(row["city"]);
                //detail.EmpType = Convert.ToString(row["Emp_Type"]);
                detail.LoanType = Convert.ToString(ds.Tables[0].Rows[0]["LoanType"]);
                detail.Income = Convert.ToString(ds.Tables[0].Rows[0]["Income"]);
                detail.status = Convert.ToString(ds.Tables[0].Rows[0]["status"]);
                detail.withdrawn = Convert.ToString(ds.Tables[0].Rows[0]["withdrawn"]);
               
            

            return detail;

        }
        public IList<ApproveLoans> GetUnApprovedLoans()
        {
            DataSet ds = repo.GetUnApprovedLoans();
            IList<ApproveLoans> loansList = new List<ApproveLoans>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ApproveLoans detail = new ApproveLoans();
                detail.AccountNumber = Convert.ToInt64(row["account_no"]);
                detail.Id = Convert.ToInt32(row["Id"]);
                detail.Username = Convert.ToString(row["username"]);
               // detail.Approval = Convert.ToString(row["approved"]);
               // detail.ApprovedTime = Convert.ToString(row["approved_time"]);
                //detail.ApprovedTime = row["approved_time"] != DBNull.Value ? (DateTime)row["approved_time"] : (DateTime?)null;
                detail.LoanAmount = Convert.ToString(row["loan_amount"]);
                detail.City = Convert.ToString(row["city"]);
                detail.EmpType = Convert.ToString(row["Emp_Type"]);
                detail.LoanType = Convert.ToString(row["LoanType"]);
                detail.Income = Convert.ToString(row["Income"]);

                loansList.Add(detail);
            }

            return loansList;

        }

        public void VerifyLoans(int id)
        {
            repo.VerifyLoans(id);
        }
        public void ApproveLoans(int id)
        {
            repo.ApproveLoans(id);
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
