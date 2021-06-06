using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult   //voidleri
    {

      


        //işlem sonucu ve kullanıcı bilgilendirme sonucu yönlendirme denilebilir
        bool Success { get; }  //okunabilir  ekleme işi basarılımı ? 
       string Message { get; }  //basarılı yada degil bilgi 
    }
}
