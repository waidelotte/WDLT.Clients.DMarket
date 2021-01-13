using System.ComponentModel.DataAnnotations;

namespace WDLT.Clients.DMarket.Enums
{
    public enum EDMarketGame
    {
        [Display(Name = "a8db")]
        CSGO,
        [Display(Name = "9a92")]
        DOTA2,
        [Display(Name = "tf2")]
        TeamFortress2,
        [Display(Name = "life_beyond")]
        LifeBeyond
    }
}