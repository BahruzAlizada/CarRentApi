using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CarColorValidator : AbstractValidator<CarColorDTO>
    {
        public CarColorValidator()
        {
            RuleFor(x => x.Color).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
