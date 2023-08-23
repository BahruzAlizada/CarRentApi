using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CountryMarketValidator : AbstractValidator<CountryMarketDTO>
    {
        public CountryMarketValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
