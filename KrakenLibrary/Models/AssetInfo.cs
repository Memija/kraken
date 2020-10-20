using Newtonsoft.Json;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// asset info
    /// </summary>
    public class AssetInfo
    {
        /// <summary>
        /// alternate name
        /// </summary>
        [JsonProperty("altname")]
        public string AlternateName { get; set; }

        /// <summary>
        /// asset class
        /// </summary>
        [JsonProperty("aclass")]
        public string AssetClass { get; set; }

        /// <summary>
        /// scaling decimal places for record keeping
        /// </summary>
        [JsonProperty("decimals")]
        public short Decimals { get; set; }

        /// <summary>
        /// scaling decimal places for output display
        /// </summary>
        [JsonProperty("display_decimals")]
        public short DisplayDecimals { get; set; }
    }
}
