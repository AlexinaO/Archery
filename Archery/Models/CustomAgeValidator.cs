using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Models.user;

namespace Archery.Models
{
    public class MinAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Do some validation checks here
            var result = new ValidationResult("Sorry you are not old enough");

            return result;
        }
    }