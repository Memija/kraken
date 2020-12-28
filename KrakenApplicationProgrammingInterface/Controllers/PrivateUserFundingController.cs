using KrakenLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KrakenApplicationProgrammingInterface.Controllers
{
    /// <summary>
    /// Private user funding
    /// </summary>
    /// <remarks>
    /// This is a tentative funding API and may be updated in the future.
    /// </remarks>
    [ApiController]
    [Produces("application/json")]
    [Route("api/private-user-funding")]
    public class PrivateUserFundingController : ControllerBase
    {
        private readonly Client client;

        public PrivateUserFundingController(Client clientInstance)
        {
            client = clientInstance;
        }

        /// <summary>
        /// Get deposit methods
        /// </summary>
        /// <returns>
        /// associative array of deposit methods
        /// </returns>
        /// <see cref="DepositMethod"/>
        /// <remarks>
        /// https://www.kraken.com/features/api#deposit-methods
        /// </remarks>
        [HttpGet("get-deposit-methods")]
        public async Task<Response<List<DepositMethod>>> GetDepositMethods()
        {
            string getDepositMethodsEndpoint = "DepositMethods";

            return await client.GetPrivateUserData<List<DepositMethod>>($"{getDepositMethodsEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }
    }
}
