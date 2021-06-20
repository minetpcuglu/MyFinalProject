using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        //Data Tranformation Object
        //DTO:ilişkisel veri tabanlarında ilişki ıdleri yerine isimlerini döndürmek (join operasyonları)
        static void Main(string[] args)
        {
            //ProductTestleri();
            CategoryTestleri();

            Console.ReadLine();


        }

        private static void CategoryTestleri()
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //foreach (var category in categoryManager.GetCategory().Data)
            //{
            //    Console.WriteLine(category.CategoryName);

            //}

            ProductManager pm = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            foreach (var item in pm.GetById(34).Data.ProductName)
            {
                Console.WriteLine(item);
            }
        }





        private static void ProductTestleri()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            foreach (var item in productManager.GetAll().Data)
            {
                Console.WriteLine(item.ProductName); 
            }

            var result = productManager.GetAll();
           

            //foreach (var product in productManager.GetAllByCategoryId(2).Data) //2 numaralı kategorıdeki urunler 
            //{
            //    Console.WriteLine(product.ProductName);

            //}



            //foreach (var product in productManager.GetByUnitPrice(50, 100).Data) //2 numaralı kategorıdeki urunler 
            //{
            //    Console.WriteLine(product.ProductName);

            //}



            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName /*+ "/" + product.ProductName*/);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            //foreach (var product in productManager.GetProductDetails().Data) //2 numaralı kategorıdeki urunler ve kategori isimleri
            //{
            //    Console.WriteLine(product.ProductName + "/" + product.CategoryName);

            //}  yukarıkı koda tasıdık if else arasına




           



            
        }
    }
}
