using CurrencyConverter.Domain.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Service.Validators
{
    public class UsersValidator : AbstractValidator<UsersViewModel>
    {
        public UsersValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name not entered.")
                .NotNull().WithMessage("Name not entered.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail not entered.")
                .NotNull().WithMessage("E-mail not entered.")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("E-mail inválido.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password not entered.")
                .NotNull().WithMessage("Password não informada.");
        }
    }
}
