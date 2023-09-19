using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<AboutDTO>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
