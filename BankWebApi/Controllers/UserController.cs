using System;
using ModelLayer;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace BankWebApi.Controllers
{
    public class UserController : ApiController
    {
        UserService userservice;
        public UserController()
        {
            userservice=new UserService();
        }
        [HttpGet]
        public IHttpActionResult GetUserDetails(int accountNumber)
        {
           // string ss = request.Content.ReadAsStringAsync().Result;
           // Int64 accno = Convert.ToInt64(ss);
            var result = userservice.getUserDetails(accountNumber);
            return Ok<AccountDetail>(result);
        }
        [HttpPost]
        public void SendMoney(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            Transaction ts = JsonConvert.DeserializeObject<Transaction>(ss);
            userservice.sendMoney(ts);
        }
        [HttpGet]
        public IHttpActionResult transHistory(int accountNumber)
        {
            var result = userservice.transHistory(accountNumber);
            return Ok<IList<Transaction>>(result);
        }
        [HttpGet]
        public IHttpActionResult loanDetails(int accountNumber)
        {
            var result = userservice.loanDetails(accountNumber);
            return Ok<IList<Loans>>(result);
        }
        [HttpGet]
        public IHttpActionResult depositDetails(int accountNumber)
        {
            var result = userservice.depositDetails(accountNumber);
            return Ok<IList<Deposits>>(result);
        }
        [HttpPost]
        public void applyLoan(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            ApplyLoan ls = JsonConvert.DeserializeObject<ApplyLoan>(ss);
            userservice.applyLoan(ls);
        }
        [HttpPost]
        public void applyDeposit(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            Deposits ds = JsonConvert.DeserializeObject<Deposits>(ss);
            userservice.applyDeposit(ds);
        }
        [HttpGet]
        public IHttpActionResult Login(string username,string password)
        {
            // string ss = request.Content.ReadAsStringAsync().Result;
            // Int64 accno = Convert.ToInt64(ss);
            //var result = userservice.getUserDetails(accountNumber);
            var result = userservice.Login(username, password);
            return Ok<AccountDetail>(result);
        }
    }
}
