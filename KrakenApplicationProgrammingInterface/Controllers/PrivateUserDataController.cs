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
    }
}
