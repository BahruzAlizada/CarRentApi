using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class GearBoxValidator : AbstractValidator<GearBoxDTO>
    {
        public GearBoxValidator()
        {
            RuleFor(x=>x.GearBox).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
