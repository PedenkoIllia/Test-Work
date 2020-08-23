using FluentValidation;
using WEB.Models;

namespace WEB.Validators
{
    public class RecordValidator : AbstractValidator<RecordViewModel>
    {
        public RecordValidator() 
        {
            RuleFor(rec => rec.Id).NotNull();
            RuleFor(rec => rec.Code).Matches("^\\d{3}$");
            RuleFor(rec => rec.Name).NotEmpty();
        }
    }
}
