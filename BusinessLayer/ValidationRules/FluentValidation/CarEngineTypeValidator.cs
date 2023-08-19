using EntityLayer.Concrete;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CarEngineTypeValidator : AbstractValidator<CarEngineType>
    {
        public CarEngineTypeValidator()
        {
            RuleFor(x => x.EngineType).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
