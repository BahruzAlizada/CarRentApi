using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CarEngineTypeValidator : AbstractValidator<EngineTypeDTO>
    {
        public CarEngineTypeValidator()
        {
            RuleFor(x => x.EngineType).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
