using System.Collections.Generic;
using Newtonsoft.Json;

namespace WDLT.Clients.DMarket.Models
{
    public class DMarketList
    {
        [JsonProperty("objects")]
        public List<DMarketItem> Items { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }
}