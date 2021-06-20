using Castle.DynamicProxy;
using System;


namespace Core.Utilities.Interceptors
{
    //claslara yada metotlara ekleyebilirisn bir den fazla ekleyebilirsin ve atribute edilen  noktada atribute calıssın 
    //neden birden fazla : loglama yapıyorsun ve hem veri tabınına hemde bir dosyaya loglamasını isteyebiliriz

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //hangisi önce calıssın  öncelik değeri 

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
