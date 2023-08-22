using Castle.DynamicProxy;

namespace CoreLayer.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //Classlara və yaxud metodlarlara əlavə edə bilərsən.
    // AllowMultipe - Birdən daha çox əlavə edə bilərsən(Məsələn : Həm Databse həm də bir fayla loglasın)
    // İnherited - Miras alınan zaman da çalışsın
    public abstract class MethodInterceptionBaseAttribute : Attribute, Castle.DynamicProxy.IInterceptor
    {
        public int Priority { get; set; } // Öncəlik. Hansı Atribute daha öncə çalışsın.

        public virtual void Intercept(IInvocation invocation)
        {

        }
        
       
    }


}
