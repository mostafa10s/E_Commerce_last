using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common.Validator.OrderValidator
{
    public class OrderDtoValidatior : AbstractValidator<OrderDto>
    {
        public OrderDtoValidatior()
        {
      
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("ClientId is required.")
                .Length(24).WithMessage("ClientId must be 24 characters long."); 

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("TotalAmount must be greater than zero.");

            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("ShippingAddress is required.")
                .MaximumLength(250).WithMessage("ShippingAddress cannot exceed 250 characters.");

          
            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("PaymentMethod is required.")
                .Must(BeAValidPaymentMethod).WithMessage("Invalid payment method.");
        }

        private bool BeAValidPaymentMethod(string paymentMethod)
        {
          
            var validMethods = new List<string> { "CreditCard", "PayPal", "BankTransfer" };
            return validMethods.Contains(paymentMethod);
        }

    }
}
