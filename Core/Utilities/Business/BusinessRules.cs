using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] locigs)  //iş motoru yazalım Locig =?  iş kuralı 
        {
            foreach (var locig in locigs)
            {
                if (!locig.Success)
                { 
                    return locig;   //basarısız kurala uymayan  ise business iletildi 
                }
            }

            return null; 

        }
    }
}
