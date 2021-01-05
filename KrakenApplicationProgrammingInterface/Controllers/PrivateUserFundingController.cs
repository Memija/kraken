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

        /// <summary>
        /// Get deposit addresses
        /// </summary>
        /// <returns>
        /// associative array of deposit addresses
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#deposit-addresses
        /// </remarks>
        [HttpGet("get-deposit-addresses")]
        public async Task<Response<List<object>>> GetDepositAddresses()
        {
            string getDepositAddressesEndpoint = "DepositAddresses";

            return await client.GetPrivateUserData<List<object>>($"{getDepositAddressesEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get status of recent deposits
        /// </summary>
        /// <returns>
        /// array of array deposit status information
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#deposit-status
        /// </remarks>
        [HttpGet("get-deposit-status")]
        public async Task<Response<List<object>>> GetDepositStatus()
        {
            string getDepositStatusEndpoint = "DepositStatus";

            return await client.GetPrivateUserData<List<object>>($"{getDepositStatusEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get withdrawal information
        /// </summary>
        /// <returns>
        /// associative array of withdrawal info
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#get-withdrawal-info
        /// </remarks>
        [HttpGet("get-withdraw-info")]
        public async Task<Response<List<object>>> GetWithdrawInfo()
        {
            string getWithdrawInfoEndpoint = "WithdrawInfo";

            return await client.GetPrivateUserData<List<object>>($"{getWithdrawInfoEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Withdraw funds
        /// </summary>
        /// <returns>
        /// associative array of withdrawal transaction
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#withdraw-funds
        /// </remarks>
        [HttpGet("withdraw-funds")]
        public async Task<Response<List<object>>> WithdrawFunds()
        {
            string withdrawEndpoint = "Withdraw";

            return await client.GetPrivateUserData<List<object>>($"{withdrawEndpoint}{this.HttpContext.Request.QueryString.Value}");
        }

        /// <summary>
        /// Get status of recent withdrawals
        /// </summary>
        /// <returns>
        /// array of array withdrawal status information
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#withdraw-status
        /// </remarks>
        /// <param name="asset">asset being withdrawn</param>
        [HttpGet, Route("{asset}", Name="get-withdraw-status")]
        public async Task<Response<List<object>>> GetWithdrawStatus([FromRoute] string asset)
        {
            string getWithdrawStatusEndpoint = "WithdrawStatus";

            return await client.GetPrivateUserData<List<object>>($"{getWithdrawStatusEndpoint}?{nameof(asset)}={asset}");
        }

        /// <summary>
        /// Request withdrawal cancelation
        /// </summary>
        /// <returns>
        /// true on success
        /// </returns>
        /// <remarks>
        /// https://www.kraken.com/features/api#withdraw-cancel
        /// **Cancelation cannot be guaranteed.**
        /// This will put in a cancelation request.
        /// Depending upon how far along the withdrawal process is, it may not be possible to cancel the withdrawal.
        /// </remarks>
        /// <param name="asset">asset being withdrawn</param>
        /// <param name="refid">withdrawal reference id</param>
        [HttpGet, Route("{asset}&{refid}", Name = "request-withdrawal-cancelation")]
        public async Task<Response<bool>> RequestWithdrawalCancelation([FromRoute] string asset, [FromRoute] string refid)
        {
            string requestWithdrawalCancelationEndpoint = "WithdrawCancel";

            return await client.GetPrivateUserData<bool>($"{requestWithdrawalCancelationEndpoint}?{nameof(asset)}={asset}&{nameof(refid)}={refid}");
        }

        /// <summary>
        /// Wallet Transfer
        /// </summary>
        /// <remarks>
        /// https://www.kraken.com/features/api#wallet-transfer
        /// </remarks>
        /// <param name="asset">asset being withdrawn</param>
        /// <param name="to">
        /// which wallet the funds are being transferred to
        /// Futures Wallet (default)
        /// </param>
        /// <param name="from">
        /// which wallet the funds are being transferred from
        /// Spot Wallet (default)
        /// </param>
        /// <param name="amount">amount to withdraw, including fees</param>
        /// <returns>
        /// associative array of transfer transaction
        /// </returns>
        [HttpGet, Route("{asset}&{to}&{from}&{amount}", Name = "wallet-transfer")]
        public async Task<Response<object>> WalletTransfer(
            [FromRoute] string asset,
            [FromRoute] string to,
            [FromRoute] string from,
            [FromRoute] string amount)
        {
            string requestWithdrawalCancelationEndpoint = "WalletTransfer";

            return await client.GetPrivateUserData<object>($"{requestWithdrawalCancelationEndpoint}?{nameof(asset)}={asset}&{nameof(to)}={to}&{nameof(from)}={from}&{nameof(amount)}={amount}");
        }
    }
}
