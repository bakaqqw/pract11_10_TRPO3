using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract9_trpo.Validation
{
    class RequiredRule :ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Необходимо заполнить поле");
            }
            return ValidationResult.ValidResult;
        }
    }
}
