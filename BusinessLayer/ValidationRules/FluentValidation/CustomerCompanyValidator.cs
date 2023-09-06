using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CustomerCompanyValidator : AbstractValidator<CompanyDTO>
    {
        public CustomerCompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Düzgün email adressini daxil edin");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
