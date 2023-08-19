using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class NumberSeatValidator : AbstractValidator<CarNumberSeat>
    {
        public NumberSeatValidator()
        {
            RuleFor(x => x.NumberSeat).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
