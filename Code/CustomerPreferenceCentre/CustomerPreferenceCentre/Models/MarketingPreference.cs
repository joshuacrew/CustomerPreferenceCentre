using System;
using CustomerPreferenceCentre.Models.CustomValidation;
using Microsoft.AspNetCore.Hosting;

namespace CustomerPreferenceCentre.Models
{
    [OnlyOneProperty(ErrorMessage = "Only one MarketingPreference can be selected.")]
    public class MarketingPreference
    {
        public bool? Never { get; set; }
        public bool? Everyday { get; set; }
        public DateTime? Date { get; set; }
        public string[] Days { get; set; }
    }
}