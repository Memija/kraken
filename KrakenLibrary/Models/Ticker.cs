using Newtonsoft.Json;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// Ticker
    /// </summary>
    public class Ticker
    {
        /// <summary>
        /// ask array(price, whole_lot_volume, lot_volume)
        /// </summary>
        [JsonProperty("a")]
        public decimal[] Ask { get; set; }

        /// <summary>
        /// bid array(price, whole_lot_volume, lot_volume)
        /// </summary>
        [JsonProperty("b")]
        public decimal[] Bid { get; set; }

        /// <summary>
        /// last trade closed array(price, lot_volume)
        /// </summary>
        [JsonProperty("c")]
        public decimal[] LastTradeClosed { get; set; }

        /// <summary>
        /// volume array(today, last_24_hours)
        /// </summary>
        [JsonProperty("v")]
        public decimal[] Volume { get; set; }

        /// <summary>
        /// volume weighted average price array(today, last_24_hours)
        /// </summary>
        [JsonProperty("p")]
        public decimal[] VolumeWeightedAveragePrice { get; set; }

        /// <summary>
        /// number of trades array(today, last_24_hours)
        /// </summary>
        [JsonProperty("t")]
        public int[] NumberOfTrades { get; set; }

        /// <summary>
        /// low array(today, last_24_hours>)
        /// </summary>
        [JsonProperty("l")]
        public decimal[] Low { get; set; }

        /// <summary>
        /// high array(today, last_24_hours)
        /// </summary>
        [JsonProperty("h")]
        public decimal[] High { get; set; }

        /// <summary>
        /// today's opening price
        /// </summary>
        [JsonProperty("o")]
        public decimal TodayOpeningPrice { get; set; }
    }
}
