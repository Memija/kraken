using Newtonsoft.Json;
using System.Collections.Generic;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// array of pair name and market depth
    /// </summary>
    public class OrderBook
    {
        /// <summary>
        /// ask side array of array entries(price, volume, timestamp)
        /// </summary>
        [JsonProperty("asks")]
        public List<object[]> Asks { get; set; }

        /// <summary>
        /// bid side array of array entries(price, volume, timestamp)
        /// </summary>
        [JsonProperty("bids")]
        public List<object[]> Bids { get; set; }
    }
}
