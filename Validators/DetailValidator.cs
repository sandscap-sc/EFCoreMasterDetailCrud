using FluentValidation;
using FrameworkLab.Models;

namespace FrameworkLab.Validators
{
    public class DetailValidator : AbstractValidator<DetailModel>
    {
        public DetailValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
            RuleForEach(a => a.Details).SetValidator(new DetailOfDetailValidator());
        }
    }
}