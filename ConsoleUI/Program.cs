using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //Data Tranformation Object
        //DTO:ilişkisel veri tabanlarında ilişki ıdleri yerine isimlerini döndürmek (join operasyonları)
        static void Main(string[] args)
        {
            ProductTestleri();
            //CategoryTestleri();



        }

        private static void CategoryTestleri()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTestleri()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
           

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
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
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
