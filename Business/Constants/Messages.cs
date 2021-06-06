using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants //sabit demek
{
    public static class Messages   //statik verildği zaman newlenmez oyuzden statik yapıldı 
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
    }
}
