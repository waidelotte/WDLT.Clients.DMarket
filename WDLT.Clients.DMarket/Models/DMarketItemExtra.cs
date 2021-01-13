using Newtonsoft.Json;

namespace WDLT.Clients.DMarket.Models
{
    public class DMarketItemExtra
    {
        [JsonProperty("tradable")]
        public bool Tradable { get; set; }

        [JsonProperty("tradeLockDuration")]
        public long TradeLockDuration { get; set; }
    }
}