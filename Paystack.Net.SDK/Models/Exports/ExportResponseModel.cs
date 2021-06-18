using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Models.Exports
{
    public class ExportResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string path { get; set; }
    }
}
