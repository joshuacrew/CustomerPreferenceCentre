using CustomerPreferenceCentre.Models.Request;
using CustomerPreferenceCentreTests.Infrastructure;
using NUnit.Framework;
using Shouldly;
using System.Linq;

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

        [Test]
        public void ShouldRequireAtLeastOneDayIsSelected()
        {
            var modelToValidate = new MarketingPreference
            {
                Days = new []{ "a"}
            };

            var validationResults = modelToValidate.ValidationResults();

            validationResults.Count.ShouldBe(1);
            validationResults.First().ErrorMessage.ShouldBe(
                "Days must only contain 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'");
        }

        [TestCase(0)]
        [TestCase(29)]
        public void ShouldOnlyAllowNumbersBetween1And28Selected(int date)
        {
            var modelToValidate = new MarketingPreference
            {
                Date = date
            };

            var validationResults = modelToValidate.ValidationResults();

            //validationResults.Count.ShouldBe(1);
            validationResults.First().ErrorMessage.ShouldBe("The field Date must be between 1 and 28.");
        }
    }
}
