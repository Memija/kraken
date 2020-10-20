using Newtonsoft.Json;
using System.Collections.Generic;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// Asset pair
    /// </summary>
    public class AssetPair
    {
        /// <summary>
        /// alternate pair name
        /// </summary>
        [JsonProperty("altname")]
        public string AlternateName { get; set; }

        /// <summary>
        /// WebSocket pair name (if available)
        /// </summary>
        [JsonProperty("wsname")]
        public string WebSocketName { get; set; }

        /// <summary>
        /// asset class of base component
        /// </summary>
        [JsonProperty("aclass_base")]
        public string AssetClassBase { get; set; }

        /// <summary>
        /// asset id of base component
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }

        /// <summary>
        /// asset class of quote component
        /// </summary>
        [JsonProperty("aclass_quote")]
        public string AssetClassQuote { get; set; }

        /// <summary>
        /// asset id of quote component
        /// </summary>
        [JsonProperty("quote")]
        public string Quote { get; set; }

        /// <summary>
        /// volume lot size
        /// </summary>
        [JsonProperty("lot")]
        public string Lot { get; set; }

        /// <summary>
        /// scaling decimal places for pair
        /// </summary>
        [JsonProperty("pair_decimals")]
        public short PairDecimals { get; set; }

        /// <summary>
        /// scaling decimal places for volume
        /// </summary>
        [JsonProperty("lot_decimals")]
        public short LotDecimals { get; set; }

        /// <summary>
        /// amount to multiply lot volume by to get currency volume
        /// </summary>
        [JsonProperty("lot_multiplier")]
        public short LotMutliplier { get; set; }

        /// <summary>
        /// array of leverage amounts available when buying
        /// </summary>
        [JsonProperty("leverage_buy")]
        public List<short> LeverageBuy { get; set; }

        /// <summary>
        /// array of leverage amounts available when selling
        /// </summary>
        [JsonProperty("leverage_sell")]
        public List<short> LeverageSell { get; set; }

        /// <summary>
        /// fee schedule array in [volume, percent fee] tuples
        /// </summary>
        [JsonProperty("fees")]
        public List<Dictionary<int,decimal>> Fees { get; set; }

        /// <summary>
        /// maker fee schedule array in [volume, percent fee] tuples (if on maker/taker)
        /// </summary>
        [JsonProperty("fees_maker")]
        public List<Dictionary<int, decimal>> FeesMaker { get; set; }

        /// <summary>
        /// volume discount currency
        /// </summary>
        [JsonProperty("fee_volume_currency")]
        public string FeeVolumeCurrency { get; set; }

        /// <summary>
        /// margin call level
        /// </summary>
        [JsonProperty("margin_call")]
        public int MarginCall { get; set; }

        /// <summary>
        /// stop-out/liquidation margin level
        /// </summary>
        [JsonProperty("margin_stop")]
        public int MarginStop { get; set; }

        /// <summary>
        /// minimum order volume for pair
        /// </summary>
        [JsonProperty("ordermin")]
        public string OrderMin { get; set; }
    }
}
