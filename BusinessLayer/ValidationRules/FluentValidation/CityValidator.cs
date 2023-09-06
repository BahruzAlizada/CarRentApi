using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<CityDTO>
    {
        public CityValidator()
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
