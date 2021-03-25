using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofact.Validation
{
    public class ValicationAspect
    {
        public class ValidationAspect : MethodInterception
        {
            private Type _validatorType;
            //VALİDATOR TYPE İSTİYOR YANİ MANAGER DE [VALİDATİONASPECT(TYPEOF(PRODUCTVALİDATOR))]
            public ValidationAspect(Type validatorType)
            {
                if (!typeof(IValidator).IsAssignableFrom(validatorType))//EĞER GÖNDERİLEN VALİDATOR ıVALIDATOR DEGILSE HATA VER DİYORZ 
                {
                    throw new System.Exception("Bu bir doğrulama sınıfı değil.");
                }

                _validatorType = validatorType;
            }
            protected override void OnBefore(IInvocation invocation)
            {
                var validator = (IValidator)Activator.CreateInstance(_validatorType);
                var entityType = _validatorType.BaseType.GetGenericArguments()[0];
                var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
                foreach (var entity in entities)
                {
                    ValidationTool.Validate(validator, entity);
                }
            }
        }
    }
}
