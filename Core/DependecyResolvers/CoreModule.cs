using Core.CrossCuttingConcerns.Cashing;
using Core.CrossCuttingConcerns.Cashing.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependecyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection servicesCollection) //sevis bagımlılıkları çözümleyecegimiz yer 
        {
            servicesCollection.AddMemoryCache(); //.net core kendi servisi //hazır ınjection oluşturuldu
            servicesCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //startuptaki bagımlılıgı buraya cekiyoruz  //Jwt için
            servicesCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //startuptaki bagımlılıgı buraya cekiyoruz //microsoft Cache için 
            servicesCollection.AddSingleton<Stopwatch>(); //performans yavaslıgı için 
        }
    }
}
