using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Models.TransTotal
{
    public class TransactionTotal
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class TotalVolumeByCurrency
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class PendingTransfersByCurrency
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class Data
    {
        public int total_transactions { get; set; }
        public int unique_customers { get; set; }
        public int total_volume { get; set; }
        public List<TotalVolumeByCurrency> total_volume_by_currency { get; set; }
        public int pending_transfers { get; set; }
        public List<PendingTransfersByCurrency> pending_transfers_by_currency { get; set; }
    }
}
