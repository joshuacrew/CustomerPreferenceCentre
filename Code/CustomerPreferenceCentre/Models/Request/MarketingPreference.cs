using System.ComponentModel.DataAnnotations;
using CustomerPreferenceCentre.Models.CustomValidation;
using JetBrains.Annotations;

namespace CustomerPreferenceCentre.Models.Request
{
    [OnlyOneProperty(ErrorMessage = "Only one MarketingPreference can be selected.")]
    public class MarketingPreference
    {
        public bool? Never { get; set; }
        public bool? Everyday { get; set; }
        [Range(1, 28)]
        public int? Date { get; set; }

        [CanBeNull]
        [StringRange(ErrorMessage = "Days must only contain 'Monday', 'Tuesday', 'Wednesday'," +
                                    " 'Thursday', 'Friday', 'Saturday', 'Sunday'")]
        public string[] Days { get; set; } = null;
    }
}