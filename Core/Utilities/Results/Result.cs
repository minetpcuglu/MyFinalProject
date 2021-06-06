using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)   //product manager için ctor olusturuldu   
            //**this(success) tek parametreli olanıda  dersen kendini tekrar etmemek için ikisinide calıstırmıs oluruz
        {
            Message = message;
          
        }

        public Result(bool success)   //product manager için ctor olusturuldu
        {
           
            Success = success;
        }


        public bool Success { get; }  //sadece get yazdıgmız için yeni nesil 

        public string Message { get; }  //sadece ctor da set edilebilir 
    }
}
