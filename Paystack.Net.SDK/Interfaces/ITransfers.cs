
using Paystack.Net.SDK.Models.Transfers.Initiation;
using Paystack.Net.SDK.Models.Transfers.Recipient;
using Paystack.Net.SDK.Models.Transfers.TransferDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK
{
    public interface ITransfers
    {
        Task<TransferRecipientModel> CreateTransferRecipient(string type,string name,string account_number,
                                        string bank_code,string currency = "NGN",string description =null);

        Task<TransferRecipientListModel> ListTransferRecipients();

        Task<TransferInitiationModel> InitiateTransfer(int amount, string recipient_code, string source = "balance", string currency = "NGN", string reason = null);

        Task<TransferDetailsModel> FetchTransfer(string transfer_code);

        Task<TransferDetailsListModel> ListTransfers();

        Task<string> FinalizeTransfer(string transfer_code, string otp);
    }
}
