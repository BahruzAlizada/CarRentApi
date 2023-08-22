using Castle.DynamicProxy;
using CoreLayer.CrossCuttingConcerns.Validation;
using CoreLayer.Utilities.Interceptors;
using CoreLayer.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) // Constructor
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // VValidator olmasa əgər xəta döndür.
            {
                throw new System.Exception(AspectMessages.WrongValidationType); //AspectMessages.WrongValidationType
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) // Polimorfizm
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Reflection çalışma anında bir şeyləri çalıştırır
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Base Typeni tap onun Generic arqumentini tap
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // Və Onun parametrini tap.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
