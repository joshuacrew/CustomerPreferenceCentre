using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// This is a class-level attribute, doesn't make sense at the property level
namespace CustomerPreferenceCentre.Models.CustomValidation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OnlyOnePropertyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var typeInfo = value.GetType();

            var propertyInfo = typeInfo.GetProperties();

            var numberOfNonNullProperties = propertyInfo.Count(property => property.GetValue(value) != null);

            return numberOfNonNullProperties == 1;
        }
    }
}