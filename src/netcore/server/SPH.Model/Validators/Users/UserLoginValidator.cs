using FluentValidation;
using SPH.Model.Users;
using SPH.Model.Validators.Extensions;

namespace SPH.Model.Validators.Users
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("The email is required.");
            RuleFor(u => u.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("The email is invalid.");

            RuleFor(u => u.Password).NotPassword();
        }
    }
}
