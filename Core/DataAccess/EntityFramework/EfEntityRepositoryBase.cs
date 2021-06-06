using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> //hsngi tabloyu verirsek onun IER olur 
        //Şartlarımızı yazalım 
        where TEntity:class,IEntity,new()   //veri tabanı tablosu olcak bır sınıf olcak ve newlenemez olcak 
        where TContext:DbContext,new()       //istenilen clasları yazamayız onun db context ten ınherıtance etmesı lazım 
    
    {
        public void Add(TEntity entity)
        {
            //using : IDisposable pattern implementation of c#
            //db kullanma
            using (TContext context = new TContext()) //Nortwindcontext bellekten işi bitince temizlenmesi için 
            {
                var addedEntity = context.Entry(entity);  //eşlestirme  referansı yakala
                addedEntity.State = EntityState.Added;  //veri tabanında ne yapmak istiyorsak onu ekleme kodu
                context.SaveChanges();   //
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //Nortwindcontext bellekten işi bitince temizlenmesi için 
            {
                var deletedEntity = context.Entry(entity);  //eşlestirme  referansı yakala
                deletedEntity.State = EntityState.Deleted;  //veri tabanında ne yapmak istiyorsak onu ekleme kodu
                context.SaveChanges();   //
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)

        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);   //tek bir data getirir
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList(); //nortwindeki product tablosunu tabloyu listeye cevir ve göster
                                                                                                                         // NUll sa                                           // : Filtre var sa filtreleyip ver
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //Nortwindcontext bellekten işi bitince temizlenmesi için 
            {
                var updatedEntity = context.Entry(entity);  //eşlestirme  referansı yakala
                updatedEntity.State = EntityState.Modified;  //veri tabanında ne yapmak istiyorsak onu ekleme kodu
                context.SaveChanges();   //
            }
        }
    }
}
