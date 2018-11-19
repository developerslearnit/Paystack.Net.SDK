using Paystack.Net.Models.Transfers.Initiation;
using Paystack.Net.Models.Transfers.Recipient;
using Paystack.Net.Models.Transfers.TransferDetails;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
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
