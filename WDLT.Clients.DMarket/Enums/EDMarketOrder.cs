using System.ComponentModel.DataAnnotations;

namespace WDLT.Clients.DMarket.Enums
{
    public enum EDMarketOrder
    {
        [Display(Name = "best_deals")]
        BestDeals,
        [Display(Name = "best_discount")]
        BestDiscount,
        [Display(Name = "updated")]
        Newest,
    }
}