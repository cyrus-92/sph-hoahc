using FluentValidation;
using SPH.Model.Users;
using SPH.Model.Validators.Extensions;

namespace SPH.Model.Validators.Users
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationModel>
    {
        public UserRegistrationValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("The email is required.");
            RuleFor(u => u.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("The email is invalid.");

            RuleFor(u => u.Password).NotPassword();

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("The first name is required.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("The last name is required.");
        }
    }
}
