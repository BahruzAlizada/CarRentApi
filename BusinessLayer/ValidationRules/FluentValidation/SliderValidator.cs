using EntityLayer.DTOs;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
	public class SliderValidator : AbstractValidator<SliderDTO>
	{
        public SliderValidator()
        {
            RuleFor(x => x.Image).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
