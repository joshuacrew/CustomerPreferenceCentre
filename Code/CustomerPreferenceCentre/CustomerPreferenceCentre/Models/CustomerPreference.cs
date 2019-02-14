using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPreferenceCentre.Models
{
    public class CustomerPreference
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public MarketingPreference MarketingPreference { get; set; }
    }
}
