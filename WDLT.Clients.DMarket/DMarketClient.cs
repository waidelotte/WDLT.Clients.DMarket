using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Sodium;
using WDLT.Clients.Base;
using WDLT.Clients.DMarket.Enums;
using WDLT.Clients.DMarket.Models;
using WDLT.Utils.Extensions;

namespace WDLT.Clients.DMarket
{
    public class DMarketClient : BaseClient
    {
        private readonly string _publicKey;
        private readonly string _privateKey;

        public DMarketClient(string publicKey, string privateKey) : base("https://api.dmarket.com")
        {
            _publicKey = publicKey;
            _privateKey = privateKey;

            _client.AddDefaultHeader("X-Api-Key", _publicKey);
        }

        protected override void OnBeforeRequest(RestClient client, IRestRequest request, Proxy proxy = null)
        {
            request.AddHeader("X-Sign-Date", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());

            var patchString = request.Resource;

            var qParamas = request.Parameters
                .Where(w => w.Type == ParameterType.QueryString)
                .Select(s => s.ToString())
                .ToList();

            var bParamas = request.Parameters
                .Where(w => w.Type == ParameterType.RequestBody)
                .Select(s => s.ToString())
                .ToList();

            if (qParamas.Any())
            {
                patchString += $"?{string.Join("&", qParamas.Select(s => s.ToString()))}";
            }

            if (bParamas.Any())
            {
                patchString += JsonConvert.SerializeObject(request.Parameters
                    .Where(w => w.Type == ParameterType.RequestBody)
                    .ToDictionary(d => d.Name, d => d.Value));
            }

            var sigString = request.Method + patchString + DateTimeOffset.Now.ToUnixTimeSeconds();
            var sig = Utilities.BinaryToHex(PublicKeyAuth.SignDetached(sigString, Utilities.HexToBinary(_privateKey)));
            request.AddHeader("X-Request-Sign", $"dmar ed25519 {sig}");
        }

        public Task<DMarketList> Items(EDMarketGame game, long priceFrom = 0, long priceTo = 0, string currency = "USD", EDMarketOrder? order = null, int limit = 50, string treeFilters = null, EDMarketType? type = null, string cursor = null)
        {
            var request = new RestRequest("/exchange/v1/market/items");
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("priceFrom", priceFrom.ToString());
            request.AddQueryParameter("priceTo", priceTo.ToString());
            request.AddQueryParameter("currency", currency);
            request.AddQueryParameter("GameID", game.NameAttribute());
            if (order != null) request.AddQueryParameter("orderBy", order.Value.NameAttribute());
            if (!string.IsNullOrEmpty(treeFilters)) request.AddQueryParameter("treeFilters", treeFilters);
            if (type != null) request.AddQueryParameter("types", type.Value.ToString().ToLower());
            if (!string.IsNullOrEmpty(cursor)) request.AddQueryParameter("cursor", cursor);

            return RequestAsync<DMarketList>(request);
        }
    }
}
