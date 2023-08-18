using EntityLayer.Concrete;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class GearBoxValidator : AbstractValidator<CarGearBox>
    {
        public GearBoxValidator()
        {
            RuleFor(x=>x.GearBox).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
