using ExemploDDD.Communication.Request;
using FluentValidation;

namespace ExemploDDD.Application.UseCases.User.Register;
public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("The field name should be not empty");
        RuleFor(user => user.Email).EmailAddress().NotEmpty().WithMessage("The field email should be a valid email and not empty");
        RuleFor(user => user.Password).MinimumLength(6).WithMessage("The field password should contain at least 6 characters");
    }
}

