using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RepositoryLayer
{
    public class AdminRepository : IAdminRepository
    {
        public DataSet GetAccountDetail()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();
                string getUserDetail = "SELECT * FROM [view users]";
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
        public DataSet GetDeposits()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();
                string getUserDetail = "SELECT * FROM [MyBank].[dbo].[deposits]";
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
        public DataSet GetLoans()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();
                string getUserDetail = "SELECT * FROM [MyBank].[dbo].[Loans]";
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
        
        public void CloseAccount(Int64 accno)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();
                string getUserDetail = "delete  from Customer where accountno='" + accno + "';";
                SqlCommand cmd = new SqlCommand(getUserDetail, con);
                cmd.ExecuteNonQuery();

            }
            //throw new NotImplementedException();
            catch
            {

            }
        }
        public void ApproveLoans(int id)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();
                string getUserDetail = "SELECT * FROM [MyBank].[dbo].[Loans] where loan_id=" + id;
                SqlCommand cmd = new SqlCommand(getUserDetail, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //DataRow row = ds.Tables[0].Rows[0];
                Int32 bal = Convert.ToInt32(ds.Tables[0].Rows[0]["loan_amount"]);
                Int64 accno = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                SqlCommand cmd1 = new SqlCommand("approveloans", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.Parameters.AddWithValue("@accountno", accno);
                cmd1.Parameters.AddWithValue("@bal", bal);
                cmd1.ExecuteNonQuery();
            }
            finally { }
        }
        public void ApproveDeposits(int id)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();
                string getUserDetail = "SELECT * FROM [MyBank].[dbo].[deposits] where deposit_id=" + id;
                SqlCommand cmd = new SqlCommand(getUserDetail, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //DataRow row = ds.Tables[0].Rows[0];
                Int32 bal = Convert.ToInt32(ds.Tables[0].Rows[0]["deposit_amount"]);
                Int64 accno = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                SqlCommand cmd1 = new SqlCommand("approvedeposits", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.Parameters.AddWithValue("@accountno", accno);
                cmd1.Parameters.AddWithValue("@bal", bal);
                cmd1.ExecuteNonQuery();
            }
            finally { }
        }
        public void UpdateAccount(CreateUser cu)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();


                int boolInt = cu.IsAdmin ? 1 : 0;
                SqlCommand cmd = new SqlCommand("update", con);

                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@username", cu.UserName);
                cmd.Parameters.AddWithValue("@accountno", cu.AccountNumber);
                cmd.Parameters.AddWithValue("@firstname", cu.FirstName);
                cmd.Parameters.AddWithValue("@lastname", cu.LastName);
              //  cmd.Parameters.AddWithValue("@dob", cu.Dob);
                cmd.Parameters.AddWithValue("@phoneno", cu.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", cu.Email);
               // cmd.Parameters.AddWithValue("@aadhar_no", cu.Aadhar);
             //   cmd.Parameters.AddWithValue("@account_type", cu.AccountType);
                cmd.Parameters.AddWithValue("@balance", cu.Balance);
                cmd.Parameters.AddWithValue("@address", cu.Address);

              //  cmd.Parameters.AddWithValue("@admin", cu.IsAdmin);
                //cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();


            }
            finally
            {
                con.Close();
            }

        }

        DataSet IAdminRepository.GetAccountDetail()
        {
            throw new NotImplementedException();
        }

        DataSet IAdminRepository.GetDeposits()
        {
            throw new NotImplementedException();
        }

        DataSet IAdminRepository.GetLoans()
        {
            throw new NotImplementedException();
        }

        void IAdminRepository.ApproveLoans(int id)
        {
            throw new NotImplementedException();
        }

        void IAdminRepository.ApproveDeposits(int id)
        {
            throw new NotImplementedException();
        }

        void IAdminRepository.CloseAccount(long acc)
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(CreateUser cu, ref string errorMessage)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BankManagmentConn"].ConnectionString;
                con.Open();

                //DateTime dob = DateTime.ParseExact(Convert.ToString(cu.Dob), "dd/mm/yyyy", null);
                int boolInt = cu.IsAdmin ? 1 : 0;
                SqlCommand cmd = new SqlCommand("AddAccount", con);
                //  SqlCommand cmd1 = new SqlCommand("insert into Login(username,password,admin) values('" + cu.UserName + "','" + cu.Password + "'," + boolInt + ");", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", cu.UserName);
                //  cmd.Parameters.AddWithValue("@accountno", cu.AccountNumber);
                cmd.Parameters.AddWithValue("@firstname", cu.FirstName);
                cmd.Parameters.AddWithValue("@lastname", cu.LastName);
                cmd.Parameters.AddWithValue("@dob", DateTime.ParseExact(cu.Dob, "dd/mm/yyyy", null));
                cmd.Parameters.AddWithValue("@phoneno", cu.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", cu.Email);
                cmd.Parameters.AddWithValue("@aadhar_no", cu.Aadhar);
                cmd.Parameters.AddWithValue("@account_type", cu.AccountType);
                cmd.Parameters.AddWithValue("@balance", cu.Balance);
                cmd.Parameters.AddWithValue("@address", cu.Address);
                cmd.Parameters.AddWithValue("@password", cu.Password);
                cmd.Parameters.AddWithValue("@admin", cu.IsAdmin);
                // cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;

            }
            finally
            {
                con.Close();
            }


        }
        void IAdminRepository.UpdateAccount(CreateUser cu)
        {
            throw new NotImplementedException();
        }
    }
}
