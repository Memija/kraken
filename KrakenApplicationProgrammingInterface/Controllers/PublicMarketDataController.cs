using KrakenLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KrakenApplicationProgrammingInterface.Controllers
{
    /// <summary>
    /// Public market data
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/public-market-data")]
    public class PublicMarketDataController : ControllerBase
    {
        private readonly Client client;

        public PublicMarketDataController(Client clientInstance)
        {
            client = clientInstance;
        }

        /// <summary>
        /// Get server time
        /// </summary>
        /// <returns>
        /// Server's time
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/Time
        /// </example>
        /// <remarks>
        /// This is to aid in approximating the skew time between the server and client.
        /// https://www.kraken.com/features/api#get-server-time
        /// </remarks>
        /// <seealso cref="ServerTime"/>
        [HttpGet("get-server-time")]
        public async Task<Response<ServerTime>> GetServerTime()
        {
            string getServerTimeEndPoint = "Time";

            return await client.GetPublicMarketData<ServerTime>(getServerTimeEndPoint);
        }

        /// <summary>
        /// Get asset info
        /// </summary>
        /// <returns>
        /// array of asset names and their info
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/Assets
        /// https://api.kraken.com/0/public/Assets?aclass=currency
        /// http://api.kraken.com/0/public/Assets?asset=ADA
        /// https://api.kraken.com/0/public/Assets?aclass=currency&asset=ada
        /// </example>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-asset-info
        /// </remarks>
        /// <seealso cref="AssetInfo"/>
        [HttpGet("get-asset-info")]
        public async Task<Response<object>> GetAssetInfo()
        {
            string getAssetInfoEndpoint = "Assets";

            return await client.GetPublicMarketData<object>($"{getAssetInfoEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get tradable asset pairs
        /// </summary>
        /// <returns>
        /// array of pair names and their info
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/AssetPairs
        /// </example>
        /// <remarks>
        /// If an asset pair is on a maker/taker fee schedule, the taker side is given in "fees" and maker side in "fees_maker".
        /// For pairs not on maker/taker, they will only be given in "fees".
        /// https://www.kraken.com/features/api#get-tradable-pairs
        /// </remarks>
        /// <seealso cref="AssetPair"/>
        [HttpGet("get-tradable-asset-pairs")]
        public async Task<Response<object>> GetTradableAssetPairs()
        {
            string getTradableAssetPairsEndpoint = "AssetPairs";

            return await client.GetPublicMarketData<object>($"{getTradableAssetPairsEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get ticker information
        /// </summary>
        /// <returns>
        /// array of pair names and their ticker info
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/Ticker?pair=ADAETH
        /// </example>
        /// <remarks>
        /// Today's prices start at 00:00:00 UTC
        /// https://www.kraken.com/features/api#get-ticker-info
        /// </remarks>
        /// <seealso cref="Ticker"/>
        [HttpGet("get-ticker-info")]
        public async Task<Response<object>> GetTickerInfo()
        {
            string getTickerInfoEndpoint = "Ticker";

            return await client.GetPublicMarketData<object>($"{getTickerInfoEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get OHLC data
        /// </summary>
        /// <returns>
        /// array of pair name and OHLC data
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/OHLC?pair=ADAETH
        /// </example>
        /// <remarks>
        /// the last entry in the OHLC array is for the current, not-yet-committed frame and will always be present, regardless of the value of "since".
        /// https://www.kraken.com/features/api#get-ohlc-data
        /// </remarks>
        [HttpGet("get-open-high-low-close-data")]
        public async Task<Response<object>> GetOpenHighLowCloseData()
        {
            string getOpenHighLowCloseDataEndpoint = "OHLC";

            return await client.GetPublicMarketData<object>($"{getOpenHighLowCloseDataEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get order book
        /// </summary>
        /// <returns>
        /// array of pair name and market depth
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/Depth?pair=ADAETH
        /// https://api.kraken.com/0/public/Depth?pair=ADAETH&count=1
        /// </example>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-order-book
        /// </remarks>
        /// <seealso cref="OrderBook"/>
        [HttpGet("get-order-book")]
        public async Task<Response<object>> GetOrderBook()
        {
            string getOrderBookEndpoint = "Depth";

            return await client.GetPublicMarketData<object>($"{getOrderBookEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get recent trades
        /// </summary>
        /// <returns>
        /// array of pair name and recent trade data
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/Trades?pair=ADAETH
        /// https://api.kraken.com/0/public/Trades?pair=ADAETH&id=1603004931491795862
        /// </example>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-recent-trades
        /// </remarks>
        [HttpGet("get-recent-trades")]
        public async Task<Response<object>> GetRecentTrades()
        {
            string getRecentTradesEndpoint = "Trades";

            return await client.GetPublicMarketData<object>($"{getRecentTradesEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get recent spread data
        /// </summary>
        /// <returns>
        /// array of pair name and recent spread data
        /// </returns>
        /// <example>
        /// https://api.kraken.com/0/public/Spread?pair=ADAETH
        /// https://api.kraken.com/0/public/Spread?pair=ADAETH&since=1603013067
        /// </example>
        /// <remarks>
        /// "since" is inclusive so any returned data with the same time as the previous set should overwrite all of the previous set's entries at that time
        /// https://www.kraken.com/features/api#get-recent-trades
        /// </remarks>
        [HttpGet("get-spread-data")]
        public async Task<Response<object>> GetSpreadData()
        {
            string getSpreadDataEndpoint = "Spread";

            return await client.GetPublicMarketData<object>($"{getSpreadDataEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }
    }
}
