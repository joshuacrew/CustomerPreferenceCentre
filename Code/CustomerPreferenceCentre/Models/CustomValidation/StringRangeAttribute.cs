using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace CustomerPreferenceCentre.Models.CustomValidation
{
    public class StringRangeAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var allowableValues = new[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            return ((IList) allowableValues).Contains(value?.ToString());
        }
    }
}