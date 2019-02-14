using System.ComponentModel.DataAnnotations;

namespace CustomerPreferenceCentre.Models.Request
{
    public class CustomerPreference
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public MarketingPreference MarketingPreference { get; set; }
    }
}
