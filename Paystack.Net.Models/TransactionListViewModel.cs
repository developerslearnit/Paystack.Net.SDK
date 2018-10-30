using System.Collections.Generic;

namespace Paystack.Net.Models
{
    public class TransactionListViewModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
    }


}
