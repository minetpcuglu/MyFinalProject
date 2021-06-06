
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess  //claslarınmızı interfaceleri kolaylıkla ulasmamk ıcın ısım uzayına koymak 
{
    //generic : Constraint  = generic kısıt    
    //where T : class referans tip olabilr demek   
    //IEntity : t ya Ientitty dir yada Ientitiyden implemente olan bir nesne olabilir 
    //new() : newlenebilir olmalı yani IEntitiy newlenemez ınterface oldugu için onu bu sekilde devre dısı bırakırız
    public interface IEntityRepository<T> where T : class,IEntity,new() //ICategori ve IProduct dal olarak teker teker yapcagımıza birleştirelim burdan verilen degerleri bunun için generic yapıları kullan yada sonradan eklenen customer 
    {

        List<T> GetAll(Expression<Func<T,bool>>filter=null );  //filtreleme yapısını kullanmak ıcın (p=>p.vsvs) expression yapısını kullanırız
        T Get(Expression<Func<T, bool>> filter ); //Filtrelemeden tek bir detaya girmek için 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId); **Expression yapısından sonra bu koda ihtiyacımız yok 
    }
}
