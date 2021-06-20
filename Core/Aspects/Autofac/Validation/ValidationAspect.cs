using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)  //ınvocation metot demek  //ezilemesini istendiği metot onbefore 
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //reflector calısma anında bir seyi calısmayı saglar calısma anında ınstance olusturmak ıstersek activate.cre.. kullanırız 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];    //ardından tipinin calısma veri tipini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  //parametlerini bul 
            foreach (var entity in entities)  //gez ve validation tool kullanarak validate yap 
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
