using Newtonsoft.Json;
using WDLT.Clients.Base;

namespace WDLT.Clients.DMarket.Models
{
    public class DMarketItemPrice
    {
        [JsonProperty("DMC")]
        public long? DMC { get; set; }

        [JsonProperty("USD")]
        [JsonConverter(typeof(LongToDoublePriceJsonConverter))]
        public double USD { get; set; }
    }
}