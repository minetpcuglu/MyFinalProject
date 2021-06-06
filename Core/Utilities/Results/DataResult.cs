using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> :Result, IDataResult<T> //senbir resultsın result yapısını içeriyorsun ve oyuzden result'ın içerdiği ctorları yazıyoruz
    {
        public DataResult(T data,bool success,string message):base(success,message) //base=result
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)  //mesaj gondermek istemiyorsa
        {
            Data = data;
        }
        public T Data { get; }

       
    }
}
