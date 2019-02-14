using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomerPreferenceCentre.Models;

namespace CustomerPreferenceCentreTests.Infrastructure
{
    public static class ValidationExtensions
    {
        public static IList<ValidationResult> ValidationResults(this object modelToValidate)
        {
            var validationResults2 = new List<ValidationResult>();

            Validator.TryValidateObject(modelToValidate, new ValidationContext(modelToValidate, null, null), validationResults2,
                true);

            var validationResults1 = (IList<ValidationResult>)validationResults2;

            var validationResults = validationResults1;
            return validationResults;
        }
    }
}