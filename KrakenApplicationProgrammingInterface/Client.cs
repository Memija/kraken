using KrakenLibrary.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KrakenApplicationProgrammingInterface
{
    /// <summary>
    /// Client.
    /// </summary>
    public class Client
    {
        private static readonly string baseEndPoint = "https://api.kraken.com";
        private static readonly string version = "/0/";
        private static readonly string publicMarketDataEndPoint = "public/";
        private static readonly string privateUserDataEndPoint = "private/";

        private readonly Settings settings;

        public Client(Settings settingsInstance)
        {
            this.settings = settingsInstance;
        }

        #region Public methods

        /// <summary>
        /// Get private user data.
        /// </summary>
        /// <typeparam name="T">
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="endpoint">
        /// Endpoint.
        /// </param>
        /// <param name="input">
        /// Input.
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/>
        /// </returns>
        public async Task<Response<T>> GetPrivateUserData<T>(string endpoint, string input = null)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{baseEndPoint}{version}{privateUserDataEndPoint}{endpoint}&asset=EUR");

            string path = string.Format($"{version}{privateUserDataEndPoint}{endpoint}");
            byte[] pathBytes = Encoding.UTF8.GetBytes(path);
            long nonce = DateTime.Now.Ticks;
            string message = "nonce=" + nonce + input;
            string nonceAndMessage = nonce + Convert.ToChar(0) + message;
            byte[] hash = ComputeHash(nonceAndMessage);
            byte[] fullHashLength = new byte[pathBytes.Length + hash.Length];
            pathBytes.CopyTo(fullHashLength, 0);
            hash.CopyTo(fullHashLength, pathBytes.Length);
            byte[] base64DecodedSecred = Convert.FromBase64String(settings.PrivateKey);
            byte[] signature = GetHash(base64DecodedSecred, fullHashLength);
            string apiSignatue = Convert.ToBase64String(signature);

            httpWebRequest.Method = HttpMethod.Post.Method;
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Headers.Add("API-Key", settings.ApiKey);
            httpWebRequest.Headers.Add("API-Sign", apiSignatue);

            if (message != null)
            {
                using (StreamWriter writer = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    writer.Write(message);
                }
            }

            return await GetResponse<T>(httpWebRequest);
        }

        /// <summary>
        /// Get public market data.
        /// </summary>
        /// <typeparam name="T">
        /// Response type.
        /// </typeparam>
        /// <param name="endpoint">
        /// Endpoint.
        /// </param>
        /// <returns>
        /// <see cref="Response{T}"/>
        /// </returns>
        public async Task<Response<T>> GetPublicMarketData<T>(string endpoint)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{baseEndPoint}{version}{publicMarketDataEndPoint}{endpoint}");
            return await GetResponse<T>(httpWebRequest);
        }

        #endregion Public methods.

        #region Private methods

        private static byte[] ComputeHash(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoding = Encoding.UTF8;

                Byte[] result = hash.ComputeHash(encoding.GetBytes(value));

                return result;
            }
        }

        private static byte[] GetHash(byte[] keyBytes, byte[] messageBytes)
        {
            using (HMACSHA512 hash = new HMACSHA512(keyBytes))
            {
                Byte[] result = hash.ComputeHash(messageBytes);

                return result;
            }
        }

        private static async Task<Response<T>> GetResponse<T>(HttpWebRequest httpWebRequest)
        {
            try
            {
                using (WebResponse webResponse = await httpWebRequest.GetResponseAsync())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            string responseContent = await streamReader.ReadToEndAsync();
                            Response<T> response = JsonConvert.DeserializeObject<Response<T>>(responseContent);

                            return response;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return null;
            }
        }

        #endregion Private methods.
    }
}
