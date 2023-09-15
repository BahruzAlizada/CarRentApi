using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarDTO>
    {
        public CarValidator()
        {
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.BanId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.CarColorId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.CarGearBoxId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.CarCountryMarketId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.CarNumberSeatId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.CarYearId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.CarEngineTypeId).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Km).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.DailyPrice).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
