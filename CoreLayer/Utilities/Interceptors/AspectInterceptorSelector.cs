using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace CoreLayer.Utilities.Interceptors
{



    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> // Get Classların atributelərini oxu
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) // Get Metodların atributelərini oxu
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); // Bu Loglamadır.Avtomatik olaraq bütün Metodları Loglamaya daxil et
            

            return classAttributes.OrderBy(x => x.Priority).ToArray(); // Öncəlik dəyərinə görə sırala
        }
    }


}
