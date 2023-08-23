using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class NumberSeatValidator : AbstractValidator<NumberSeatDTO>
    {
        public NumberSeatValidator()
        {
            RuleFor(x => x.NumberSeat).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
