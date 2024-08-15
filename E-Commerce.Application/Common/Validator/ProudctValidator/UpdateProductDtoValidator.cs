using FluentValidation;


namespace E_Commerce.Application.Common.Validator.ProudctValidator
{
    public class UpdateProductDtoValidator : AbstractValidator<ProductUpdateDto>
    {

        public UpdateProductDtoValidator()
        {
            // Validate percentage
            RuleFor(x => x.percentage)
                .InclusiveBetween(0, 100).WithMessage("Percentage must be between 0 and 100.");

        }
    }
}
