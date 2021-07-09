using CurrencyConverter.Domain.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Service.Validators
{
    public class TransactionsValidator : AbstractValidator<TransactionsViewModel>
    {
        public TransactionsValidator()
        {
            RuleFor(c => c.ConversionRate)
                .NotEmpty().WithMessage("Conversion Rate not entered.")
                .NotNull().WithMessage("Conversion Rate not entered.");

            RuleFor(c => c.OriginCurrency)
                .NotEmpty().WithMessage("Origin Currency not entered.")
                .NotNull().WithMessage("Origin Currency not informada.");

            RuleFor(c => c.OriginValue)
               .NotEmpty().WithMessage("Origin Value not entered.")
               .NotNull().WithMessage("Origin Value not informada.");

            RuleFor(c => c.DestinationCurrency)
               .NotEmpty().WithMessage("Destination Currency not entered.")
               .NotNull().WithMessage("Destination Currency not informada.");

            RuleFor(c => c.DestinationValue)
             .NotEmpty().WithMessage("Destination Value not entered.")
             .NotNull().WithMessage("Destination Value not informada.");
        }
    }
}
