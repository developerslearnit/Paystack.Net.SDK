using Paystack.Net.SDK.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var paystackTransactionAPI = new PaystackTransaction("sk_test_6c48f10610a7ba9e569dc77116c838681b0e5bed");

            var response = await paystackTransactionAPI.InitializeTransaction("mark2kk@gmail.com", 500000);
            
            return View(response);
        }

        public async Task<ActionResult> FetchTransaction()
        {
            //Task<List<TransactionVerificationResponseModel>>
            var paystackTransactionAPI = new PaystackTransaction("sk_test_6c48f10610a7ba9e569dc77116c838681b0e5bed");

            var response = await paystackTransactionAPI.FetchTransaction(9149218);
            

            return View(response);
        }

        public async Task<ActionResult> GetTransactions()
        {
            //Task<List<TransactionVerificationResponseModel>>
            var paystackTransactionAPI = new PaystackTransaction("sk_test_6c48f10610a7ba9e569dc77116c838681b0e5bed");

            var response = await paystackTransactionAPI.VerifyTransaction("cipyd2ikxw");

            return View(response);
        }

        public async Task<ActionResult> ChargeAuth()
        {
            //Task<List<TransactionVerificationResponseModel>>
            var paystackTransactionAPI = new PaystackTransaction("sk_test_6c48f10610a7ba9e569dc77116c838681b0e5bed");

            var response = await paystackTransactionAPI.ChargeAuthorization("AUTH_lqnf8xjy5j", "mark2kk@gmail.com", 50);


            return View(response);
        }

        public async Task<ActionResult> TransactionTimeline()
        {
            //Task<List<TransactionVerificationResponseModel>>
            var paystackTransactionAPI = new PaystackTransaction("sk_test_6c48f10610a7ba9e569dc77116c838681b0e5bed");

            var response = await paystackTransactionAPI.TransactionTimeline("cipyd2ikxw");


            return View(response);
        }

        //TransactionTimeline
    }
}