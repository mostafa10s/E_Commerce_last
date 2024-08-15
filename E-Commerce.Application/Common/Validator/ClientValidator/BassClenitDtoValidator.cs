using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.ClientValidator
{
    public class BassClenitDtoValidator : AbstractValidator<BassClenitDto>
    {
        public BassClenitDtoValidator()
        {
            // Validate Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Validate Phone
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\+\d{1,3}\s\d{1,14}(\s\d{1,13})?$").WithMessage("Invalid phone number format."); // Example regex for international format


        }
    }
}
