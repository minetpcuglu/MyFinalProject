using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    //bütün katmanlardaki eklenecek injection ları bir arada toplayabilcegimiz bir yapı 
    //genişletebilmek için static olması lazım
   public static class ServiceCollectionExtensions
    {
        //apideki servis bagımlılıkları çözmek için kullanırız
        //neyi genişletmek istiyorsak onu this ile veriyoruz 
        //parametreleri ICoreModule olan bir array
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicesCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicesCollection);
            }
            return ServiceTool.Create(servicesCollection);
        }
    }
}
