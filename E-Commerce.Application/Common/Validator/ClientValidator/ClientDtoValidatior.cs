using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.ClientValidator
{
    public class ClientDtoValidatior : AbstractValidator<ClientDto>
    {
        public ClientDtoValidatior()
        {
          
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

    
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(250).WithMessage("Address cannot exceed 250 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .Must(BeAValidAge).WithMessage("Client must be at least 18 years old.");

            
            Include(new BassClenitDtoValidator());
        }

        private bool BeAValidAge(DateTime dateOfBirth)
        {
           
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            return age >= 18;
        }
    

    }
}
