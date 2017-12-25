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
    }
}