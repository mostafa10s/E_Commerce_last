using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.CategoryValidator
{
    public class UpdateCategoryNameDtoValidator : AbstractValidator<UpdateCategoryNameDto>
    {
        public UpdateCategoryNameDtoValidator()
        {
       
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category Name is required.")
                .MaximumLength(100).WithMessage("Category Name cannot exceed 100 characters.");
        }

    }
}
