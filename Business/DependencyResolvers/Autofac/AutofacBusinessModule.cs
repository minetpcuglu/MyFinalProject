using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCSDemo;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module // ne işe yarar startup ta yazdıgımız bagımlılıkları burada çözmemizi saglar
    {
        protected override void Load(ContainerBuilder builder) //ezilebilecek metotlar
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();  //  services.AddSingleton<IProductService,ProductManager>();  buna karsılık gelen  biri senden ıproduct service isterse ona bir ı product manager instance(örneği) ver
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();  //  services.AddSingleton<IProductService,ProductManager>();  buna karsılık gelen  biri senden ıproduct service isterse ona bir ı product manager instance(örneği) ver
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

          

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();   //bu autofac ile yazılan kuralları saglama kodu 

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }
    }
}
