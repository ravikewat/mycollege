using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCollege.Validators
{
    public class EmailExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            string email = value.ToString();
            ErrorMessage = ErrorMessage ?? "Email already exists";
            if (!string.IsNullOrEmpty(email))
            {
                if (email.Equals("ravi.kewat@gmail.com"))
                    return new ValidationResult(ErrorMessage);
                else
                    return ValidationResult.Success;
            }
            else
                return ValidationResult.Success;
        }
    }
}