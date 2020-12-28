using Newtonsoft.Json;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// Deposit method
    /// </summary>
    public class DepositMethod
    {
        /// <summary>
        /// name of deposit method
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// maximum net amount that can be deposited right now, or false if no limit
        /// </summary>
        [JsonProperty("limit")]
        public string Limit { get; set; }

        /// <summary>
        /// amount of fees that will be paid
        /// </summary>
        [JsonProperty("fee")]
        public string Fee { get; set; }

        /// <summary>
        /// whether or not method has an address setup fee(optional)
        /// </summary>
        [JsonProperty("address-setup-fee")]
        public string AddressSetupFee { get; set; }
    }
}
