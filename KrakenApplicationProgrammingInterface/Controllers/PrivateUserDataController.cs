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
    }
}
