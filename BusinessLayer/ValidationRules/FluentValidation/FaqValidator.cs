using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class FaqValidator : AbstractValidator<FaqDTO>
    {
        public FaqValidator()
        {
            RuleFor(x => x.Quetsion).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
