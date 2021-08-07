using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Cashing
{
  public interface ICacheManager
    {
        void Add(string key,object value,int duration); //duration ? ne kadar durcak
        T Get<T>(string key);  //hangi tipte geriye ne dönecek 
       object Get(string key);
        bool IsAdd(string key); //cashe de varmı veri t. danmı getircez kontrol 
        void Remove(string key);
        void RemoveByPattern(string pattern);  //filtreleme içinde caetgory olan içinde get olan vsvs

    }
}
