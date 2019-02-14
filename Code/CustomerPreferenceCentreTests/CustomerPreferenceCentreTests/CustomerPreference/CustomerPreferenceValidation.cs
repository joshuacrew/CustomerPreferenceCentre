using System.Linq;
using CustomerPreferenceCentre.Models;
using CustomerPreferenceCentre.Models.Request;
using CustomerPreferenceCentreTests.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace CustomerPreferenceCentreTests.CustomerPreference
{
    class CustomerPreferenceValidation
    {
        [Test]
        public void ShouldRequireCustomerName()
        {
            var modelToValidate = new CustomerPreferenceCentre.Models.Request.CustomerPreference
            {
                MarketingPreference = new MarketingPreference
                {
                    Never = true
                }
            };

            var validationResults = modelToValidate.ValidationResults();

            validationResults.Count.ShouldBe(1);
            validationResults.First().ErrorMessage.ShouldBe("The CustomerName field is required.");
        }

        [Test]
        public void ShouldRequireMarketingPreference()
        {
            var modelToValidate = new CustomerPreferenceCentre.Models.Request.CustomerPreference
            {
                CustomerName = "a",
            };

            var validationResults = modelToValidate.ValidationResults();

            validationResults.Count.ShouldBe(1);
            validationResults.First().ErrorMessage.ShouldBe("The MarketingPreference field is required.");
        }

        [Test]
        public void ShouldRequireOnlyOneMarketingPreferenceIsSelected()
        {
            var modelToValidate = new MarketingPreference
            {
                Everyday = true,
                Never = true

            };

            var validationResults = modelToValidate.ValidationResults();

            validationResults.Count.ShouldBe(1);
            validationResults.First().ErrorMessage.ShouldBe("Only one MarketingPreference can be selected.");
        }
    }
}
