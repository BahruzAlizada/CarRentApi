using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class SubCategoryValidator : AbstractValidator<SubCategory>
    {
        public SubCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad boş keçilə bilməz");
        }
    }
}
