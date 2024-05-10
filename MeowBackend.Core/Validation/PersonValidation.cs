using FluentValidation;
using MeowBackend.Core.Models.Requestes;
namespace MeowBackend.Core.Validation;

public class PersonValidation: AbstractValidator<CreatePersonRequest>
{
    public PersonValidation()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Заполните имя пользователя");
        RuleFor(user => user.Password).NotEmpty().WithMessage("Заполните пароль пользователя")
            .MinimumLength(5).WithMessage("Пароль должен содержать минимум 5 символов")
            .Matches(@"[0-9]+").WithMessage("Пароль должен содержать минимум 1 цифру")
            .Matches(@"[\!\?\*\.]+").WithMessage("Пароль должен содержать хотя бы 1 специальный символ");
        RuleFor(user => user.Email)
          .EmailAddress()
          .WithMessage("Введите правильную почту");
    }
}
