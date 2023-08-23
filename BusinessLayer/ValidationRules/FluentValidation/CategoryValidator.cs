using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
        }
    }
}
