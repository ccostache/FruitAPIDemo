using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FruitApi.DTO.DataValidatorAttributes
{
    /// <summary>
    /// Custom data annotation used to check if a field is a valid fruit name as defined for the services being used
    /// </summary>
    internal class ValidFruitNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fruitName = value as String;

            const string pattern = "^[a-zA-Z]{3,20}$";

            return Regex.Match(fruitName, pattern).Success ? ValidationResult.Success : new ValidationResult("Fruit name did not match expected pattern");
        }
    }
}
