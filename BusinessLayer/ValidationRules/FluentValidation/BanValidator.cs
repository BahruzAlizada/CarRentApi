using EntityLayer.Concrete;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BanValidator : AbstractValidator<Ban>
    {
        public BanValidator()
        {
            RuleFor(x=>x.BanName).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
