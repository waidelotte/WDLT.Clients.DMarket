using System.Runtime.Serialization;

namespace WDLT.Clients.DMarket.Enums
{
    public enum EDMarketGame
    {
        [EnumMember(Value = "a8db")]
        CSGO,
        [EnumMember(Value = "9a92")]
        DOTA2,
        [EnumMember(Value = "tf2")]
        TeamFortress2,
        [EnumMember(Value = "life_beyond")]
        LifeBeyond
    }
}