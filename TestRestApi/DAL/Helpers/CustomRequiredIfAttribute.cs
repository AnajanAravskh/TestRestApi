using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Helpers
{
    public class CustomRequiredIfAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customProp3 = validationContext.ObjectType.GetProperty("CustomProperty3");
            if(customProp3 != null && DateTime.TryParse(customProp3.GetValue(validationContext.ObjectInstance).ToString(), out var prop3Value) && prop3Value >= new DateTime(2018, 5, 1))
            {
                if (value == null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}
