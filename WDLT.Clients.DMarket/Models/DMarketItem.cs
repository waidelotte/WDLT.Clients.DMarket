using Newtonsoft.Json;

namespace WDLT.Clients.DMarket.Models
{
    public class DMarketItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("classId")]
        public string ClassId { get; set; }

        [JsonProperty("GameId")]
        public string GameId { get; set; }

        [JsonProperty("discount")]
        public int Discount { get; set; }

        [JsonProperty("price")]
        public DMarketItemPrice Price { get; set; }

        [JsonProperty("extra")]
        public DMarketItemExtra Extra { get; set; }
    }
}