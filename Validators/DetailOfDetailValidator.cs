using FluentValidation;
using FrameworkLab.Models;

namespace FrameworkLab.Validators
{
    public class DetailOfDetailValidator : AbstractValidator<DetailOfDetailModel>
    {
        public DetailOfDetailValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
        }
    }
}