using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.CategoryValidator
{
    public class UpdateCategoryDiscValidator : AbstractValidator<UpdateCategoryDescriptionDto>
    {
        public UpdateCategoryDiscValidator()
        {
           
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }

    }
}
