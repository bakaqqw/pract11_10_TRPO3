using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract9_trpo.Validation
{
    public class PhoneRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
       cultureInfo)
        {
            string? input = (value ?? "").ToString().Trim();
            string pattern = @"^8 \d{3} \d{3} \d{4}$";
            if (!Regex.IsMatch(input, pattern))
            {
                return new ValidationResult(false, "Номе телефона должен быть в формате 8 ### ### ####");
            }
            return ValidationResult.ValidResult;
        }
    }
}
