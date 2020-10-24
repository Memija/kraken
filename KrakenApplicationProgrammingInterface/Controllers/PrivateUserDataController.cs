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
    /// Private user data
    /// </summary>
    [ApiController]
    [Route("api/private-user-data")]
    public class PrivateUserDataController : ControllerBase
    {
        private readonly Client client;

        public PrivateUserDataController(Client clientInstance)
        {
            client = clientInstance;
        }

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>
        /// array of asset names and balance amount
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-account-balance
        /// </remarks>
        [HttpGet("get-account-balance")]
        public async Task<Response<object>> GetAccountBalance()
        {
            string getAccountBalanceEndpoint = "Balance";

            return await client.GetPrivateUserData<object>($"{getAccountBalanceEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>
        /// array of asset names and balance amount
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-trade-balance
        /// </remarks>
        [HttpGet("get-trade-balance")]
        public async Task<Response<object>> GetTradeBalance()
        {
            string getTradeBalanceEndpoint = "TradeBalance";

            return await client.GetPrivateUserData<object>($"{getTradeBalanceEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get open orders
        /// </summary>
        /// <returns>
        /// array of order info in open array with txid as the key
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-open-orders
        /// Unless otherwise stated, costs, fees, prices, and volumes are in the asset pair's scale, not the currency's scale.
        /// For example, if the asset pair uses a lot size that has a scale of 8, the volume will use a scale of 8, even if the currency it represents only has a scale of 2.
        /// Similarly, if the asset pair's pricing scale is 5, the scale will remain as 5, even if the underlying currency has a scale of 8.
        /// </remarks>
        [HttpGet("get-open-orders")]
        public async Task<Response<object>> GetOpenOrders()
        {
            string getOpenOrdersEndpoint = "OpenOrders";

            return await client.GetPrivateUserData<object>($"{getOpenOrdersEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get closed orders
        /// </summary>
        /// <returns>
        /// array of order info
        /// </returns>
        /// <remarks>
        /// https://api.kraken.com/0/private/ClosedOrders
        /// Times given by order tx ids are more accurate than unix timestamps.
        /// If an order tx id is given for the time, the order's open time is used
        /// </remarks>
        [HttpGet("get-closed-orders")]
        public async Task<Response<object>> GetClosedOrders()
        {
            string getClosedOrdersEndpoint = "ClosedOrders";

            return await client.GetPrivateUserData<object>($"{getClosedOrdersEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Query orders info
        /// </summary>
        /// <returns>
        /// associative array of orders info
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#query-orders-info
        /// </remarks>
        [HttpGet("query-orders-info")]
        public async Task<Response<object>> QueryOrdersInfo()
        {
            string queryOrdersInfoEndpoint = "QueryOrders";

            return await client.GetPrivateUserData<object>($"{queryOrdersInfoEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get trades history
        /// </summary>
        /// <returns>
        /// array of trade info
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-trades-history
        /// Unless otherwise stated, costs, fees, prices, and volumes are in the asset pair's scale, not the currency's scale.
        /// Times given by trade tx ids are more accurate than unix timestamps.
        /// </remarks>
        [HttpGet("get-trades-history")]
        public async Task<Response<object>> GetTradesHistory()
        {
            string getTradesHistoryEndpoint = "TradesHistory";

            return await client.GetPrivateUserData<object>($"{getTradesHistoryEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Query trades info
        /// </summary>
        /// <returns>
        /// associative array of trades info
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#query-trades-info
        /// </remarks>
        [HttpGet("query-trades-info")]
        public async Task<Response<object>> QueryTradesInfo()
        {
            string queryTradesInfoEndpoint = "QueryTrades";

            return await client.GetPrivateUserData<object>($"{queryTradesInfoEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }
    }
}
