using Business.Abstract;
using Business.Concrete;
using Core.DependecyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            //bu yapýyý daha farklý bir mimariye tasýyacaz onlar Autofac, ninject Castlewindsor , structureMap , DryInject ---> IoC Container 
            //AOP //Autofac kullanýcaz

            services.AddControllers();  //singleton içerisinde data tutmuyorsak kullanýlýr 
                                        //services.AddSingleton<IProductService,ProductManager>();  // senden biri IPS Isterse sen arka planda PM olustur // arka plandacalýscak referans olustur 
                                        //services.AddSingleton<IProductDal, EfProductDal>();  //bagýmlýlýklarý gideriyoruz

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  //dependecy injection apý 

            services.AddCors();
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // bu sistemde authtikasyon olarak jwt kullanýlcak 

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                    };
                });

            //istediðimiz kadar module (core modulu vs) baska modulleride kullanabiliriz
            //ServiceTool.AddDependencyResolvers();

            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });





        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); //middleware devreye sokuyoruz 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
