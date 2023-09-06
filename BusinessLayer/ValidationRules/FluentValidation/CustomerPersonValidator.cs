using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CustomerPersonValidator : AbstractValidator<PersonDTO>
    {
        public CustomerPersonValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Düzgün email adressini daxil edin");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
