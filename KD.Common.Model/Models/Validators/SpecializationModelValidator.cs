using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Common.Model.Models.Validators
{
    public class SpecializationModelValidator : BaseValidator<SpecializationModel>
    {
        public SpecializationModelValidator()
        {
            RuleFor(s => s.Name).MinimumLength(10);
        }
    }
}
