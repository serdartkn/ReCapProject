using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //aşağıdaki şekil bir kullanım var olan ve olacak tüm metotlara performans yönetimi uygular başka bir aspect eklenmesi halinde
            //o aspect'de yine tüm metotlarda iş görür olacaktır.
            //classAttributes.Add(new Performance(5));
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
