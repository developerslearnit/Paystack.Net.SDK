using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK
{
    public static class BaseConstants
    {
        public const string PaystackBaseEndPoint = "https://api.paystack.co/";


        public const string PaystackInitializeTransactionEndPoint = "transaction/initialize";
        public const string PaystackTransactionVerificationEndPoint = "transaction/verify";

        /// <summary>
        /// Application - Json Content Type
        /// </summary>
        public const string ContentTypeHeaderJson = "application/json";

       
        /// <summary>
        /// Authorization HTTP Header
        /// </summary>
        public const string AuthorizationHeaderType = "Bearer";
    }
}
