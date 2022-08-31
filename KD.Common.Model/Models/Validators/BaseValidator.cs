using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Common.Model.Models.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator()
        {
            CascadeMode = CascadeMode.Continue;
        }

        public PropertyValidationResult ValidatePropert(T instanceToValidate, string propertyName)
        {
            var validationResult = Validate(instanceToValidate);

            return new PropertyValidationResult()
            {
                isValid = validationResult.IsValid,
                Errors = validationResult.Errors.Where(error => error.PropertyName == propertyName).ToList()
            };
        }
    }
}

