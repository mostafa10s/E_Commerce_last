using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.ProudctValidator
{
    public class BassProductDtoValidator : AbstractValidator<BassProductDto>
    {
        public BassProductDtoValidator()
        {
            RuleFor(proudct => proudct.ProductName).Length(20);
            RuleFor(proudct => proudct.Description).NotNull().NotEmpty();
            RuleFor(proudct => proudct.Stock).GreaterThanOrEqualTo(0);
            RuleFor(proudct => proudct.Price).GreaterThan(0);


        }
    }
}
