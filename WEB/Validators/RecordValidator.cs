using FluentValidation;
using LogicLayer.DataTransferObjects;

namespace WEB.Validators
{
    public class RecordValidator : AbstractValidator<RecordDTO>
    {
        public RecordValidator()
        {
            RuleFor(rec => rec.Code).Matches("^\\d{3}$").WithMessage("Поле Значение должно состоять из трех цифр!");
            RuleFor(rec => rec.Name).NotEmpty().WithMessage("Поле Имя не может быть пустым");

            RuleSet("CorrectId", () =>
            {
                RuleFor(x => x.Id).NotEqual(0).WithMessage("Необходимо указать корректный Id");
            });
        }
    }
}
