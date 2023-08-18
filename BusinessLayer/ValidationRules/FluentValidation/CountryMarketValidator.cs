using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CountryMarketValidator : AbstractValidator<CarCountryMarket>
    {
        public CountryMarketValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
