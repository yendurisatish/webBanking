using System;
using ModelLayer;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
   public class UserRepository
    {
       public DataSet getUserDetails(Int64 accno)
       {
           SqlConnection con = new SqlConnection();
           try
           {
               con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
               con.Open();
               string getUserDetail = "SELECT * FROM Customer where accountno="+accno;
               SqlCommand cmd = new SqlCommand(getUserDetail, con);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
           //throw new NotImplementedException();
           catch
           {
               return null;
           }
       }
       public void sendMoney(Transaction ts)
       {
           SqlConnection con = new SqlConnection();
           try
           {
               con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
               con.Open();
              
              
               SqlCommand cmd1 = new SqlCommand("sendmoney", con);
               cmd1.CommandType = CommandType.StoredProcedure;
               cmd1.Parameters.AddWithValue("@senderaccount", ts.senderaccount);
               cmd1.Parameters.AddWithValue("@targetaccount",ts.targetaccount );
               cmd1.Parameters.AddWithValue("@bal", ts.balance);
               cmd1.ExecuteNonQuery();
           }
           finally { }
       }
       public DataSet transHistory(Int64 accno)
       {
           SqlConnection con = new SqlConnection();
           try
           {
               con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
               con.Open();
               string getUserDetail = "select * from [dbo].[Transaction] where trans_account=" + accno + " or oth_account=" + accno ;
               SqlCommand cmd = new SqlCommand(getUserDetail, con);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
           //throw new NotImplementedException();
           catch
           {
               return null;
           }
       }


       public DataSet loanDetails(Int64 accno)
       {
           SqlConnection con = new SqlConnection();
           try
           {
               con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
               con.Open();
               string loanDetail = "select * from [dbo].[Loans] where account_no=" + accno ;
               SqlCommand cmd = new SqlCommand(loanDetail, con);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
           //throw new NotImplementedException();
           catch
           {
               return null;
           }
       }
       public DataSet depositDetails(Int64 accno)
       {
           SqlConnection con = new SqlConnection();
           try
           {
               con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
               con.Open();
               string depositDetail = "select * from [dbo].[deposits] where accountno=" + accno;
               SqlCommand cmd = new SqlCommand(depositDetail, con);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
           //throw new NotImplementedException();
           catch
           {
               return null;
           }
       }
      public void applyLoan(ApplyLoan al)
       {
           SqlConnection con = new SqlConnection();
           con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
           con.Open();
           try
           {
               SqlCommand cmd = new SqlCommand("applyLoan", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@accountNumber", al.AccountNumber);
               cmd.Parameters.AddWithValue("@loanType", al.LoanType);
               cmd.Parameters.AddWithValue("@income", al.Income);
               cmd.Parameters.AddWithValue("@payslip", al.Payslip);
               cmd.Parameters.AddWithValue("@photo", al.Photo);
               cmd.Parameters.AddWithValue("@signature", al.Signature);
               cmd.Parameters.AddWithValue("@loanAmount", al.LoanAmount);
               cmd.Parameters.AddWithValue("@empType", al.EmpType);
               cmd.Parameters.AddWithValue("@city", al.City);
               cmd.ExecuteNonQuery();
           }
           finally
           {

               con.Close();
           }
       }
      public void applyDeposit(Deposits ds)
      {
          SqlConnection con = new SqlConnection();
          try
          {
              con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
              con.Open();
              SqlCommand cmd1 = new SqlCommand("insert into deposits(accountno,deposit_amount,duration,approved) values('" + ds.AccountNumber + "','" + ds.DepositAmount + "','" + ds.Duration + "','no')", con);
              cmd1.ExecuteNonQuery();
          }
          finally
          {
              con.Close();
          }
      }


      public DataSet Login(string username,string password)
      {
          SqlConnection con = new SqlConnection();
          try
          {
              con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
              con.Open();
              SqlCommand cmd = new SqlCommand("select * from Customer where username='" + username + "' and password='" + password + "'", con);
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              DataSet ds = new DataSet();
              da.Fill(ds);
              return ds;
          }
          //throw new NotImplementedException();
          catch
          {
              return null;
          }
      }
    }
}
