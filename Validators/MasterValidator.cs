using FluentValidation;
using FrameworkLab.Models;

namespace FrameworkLab.Validators
{
    public class MasterValidator : AbstractValidator<MasterModel>
    {
        public MasterValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
            RuleForEach(a => a.Details).SetValidator(new DetailValidator());
        }
    }
}