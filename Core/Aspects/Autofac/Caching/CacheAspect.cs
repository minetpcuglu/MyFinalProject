using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Cashing;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //?? varsa bunu yoksa bunu demek 
            if (_cacheManager.IsAdd(key)) //cache içinde varsa if metodu calisir 
            {
                invocation.ReturnValue = _cacheManager.Get(key); //metodun return degeri (ınnocation) cachedeki data olsun demek 
                return;
            }
            invocation.Proceed(); //yoksa proceed eder
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
