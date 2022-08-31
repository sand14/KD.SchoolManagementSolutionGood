using FluentValidation;

namespace KD.Common.Model.Models.Validators
{
    public class CourseModelValidator : BaseValidator<CourseModel>
    {
        public CourseModelValidator()
        {
            RuleFor(s => s.Description).NotEmpty().MinimumLength(10);
            RuleFor(s => s.Specialization).SetValidator(new SpecializationModelValidator());
        }
    }
}
