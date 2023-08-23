using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class NewsletterValidator : AbstractValidator<Newsletter>
    {
        public NewsletterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresini düzgün daxil edin");
        }
    }
}
