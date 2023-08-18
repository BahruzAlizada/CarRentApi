﻿using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CarYearValidator : AbstractValidator<CarYear>
    {
        public CarYearValidator()
        {
            RuleFor(x=>x.Year).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
