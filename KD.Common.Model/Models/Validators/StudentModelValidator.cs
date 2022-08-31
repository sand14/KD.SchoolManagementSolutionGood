using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Common.Model.Models.Validators
{
    public class StudentModelValidator : BaseValidator<StudentModel>
    {
        public StudentModelValidator()
        {
            RuleFor(s => s.FirstName).NotNull();
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.DateOfBirth).GreaterThan(DateTime.Today.AddYears(-10));
        }

    }
}
