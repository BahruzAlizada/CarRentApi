using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategoryDTO>
    {
        public SubCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad boş keçilə bilməz");
        }
    }
}
