using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.OrderValidator
{
    public class BassOrderItemDtoValidatior : AbstractValidator<BassOrderDto>
    {
        public BassOrderItemDtoValidatior()
        {
      
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.")
                .Length(24).WithMessage("ProductId must be 24 characters long."); 

         
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("ProductName is required.")
                .MaximumLength(100).WithMessage("ProductName cannot exceed 100 characters.");

           
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
