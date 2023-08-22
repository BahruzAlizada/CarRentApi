using FluentValidation;
using System;
using ValidationException = FluentValidation.ValidationException;

namespace CoreLayer.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
       public static void Validate(IValidator validator,object entity) 
          // Object entity Nəyi Validate etsin
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
