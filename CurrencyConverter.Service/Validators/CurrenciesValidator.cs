using CurrencyConverter.Domain.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Service.Validators
{
    public class CurrenciesValidator : AbstractValidator<CurrenciesViewModel>
    {
        public CurrenciesValidator()
        {
            RuleFor(c => c.Currency)
                .NotEmpty().WithMessage("Currency not entered.")
                .NotNull().WithMessage("Currency not entered.");

            RuleFor(c => c.Currencycode)
                .NotEmpty().WithMessage("Currency Code not entered.")
                .NotNull().WithMessage("Currency Code not entered.");
        }
    }
}
