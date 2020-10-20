using Newtonsoft.Json;

namespace KrakenLibrary.Models
{
    /// <summary>
    /// Server's time
    /// </summary>
    public class ServerTime
    {
        /// <summary>
        /// unix timestamp
        /// </summary>
        [JsonProperty("unixtime")]
        public long UnixTime { get; set; }

        /// <summary>
        /// RFC 1123 time format
        /// </summary>
        [JsonProperty("rfc1123")]
        public string Rfc1123 { get; set; }
    }
}
