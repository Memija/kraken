using Newtonsoft.Json;
using System.Collections.Generic;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// response
    /// </summary>
    /// <typeparam name="T">result</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// error
        /// </summary>
        [JsonProperty("error")]
        public IList<string> Error { get; set; }

        /// <summary>
        /// result
        /// </summary>
        [JsonProperty("result")]
        public T Result;
    }
}
