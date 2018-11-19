namespace Paystack.Net.Models.Authorizations
{
    public class RequestAuthorizationModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string reauthorization_url { get; set; }
        public string reference { get; set; }
    }
}
