using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Archery.Models
{
    public class Age : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                return DateTime.Now.AddYears(-9) <= (DateTime)value;
            }
            else
                throw new ArgumentException("Le type doit être un DateTime");
        }

    }
}