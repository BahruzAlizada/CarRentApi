using Castle.DynamicProxy;

namespace CoreLayer.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    //invocation - Metod deməkdir
    protected virtual void OnBefore(IInvocation invocation) { }
    protected virtual void OnAfter(IInvocation invocation) { }
    protected virtual void OnException(IInvocation invocation, System.Exception e) { }
    protected virtual void OnSuccess(IInvocation invocation) { }

    public override void Intercept(IInvocation invocation) // Polimorfizm
    {
        var isSuccess = true;
        OnBefore(invocation); // Metodun başında çalışır
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e); // Metod xəta olduqda
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation); // Metod success olduqda çalışar
            }
        }
        OnAfter(invocation); //Metod  Bitdikdən sonra çalışır
    }
}
