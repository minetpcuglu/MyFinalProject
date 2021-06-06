using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Bellek üzerinde ürünle ilgili veri erişim kodlarının yazılacağı alan 
    public class InMemoryProductDal : IProductDal
    {
       
        List<Product> _products;  //Global  bir değişken oldugu için "alt çizgi" ile kullanıyoruz

        public InMemoryProductDal()
        {
            //Veri varmış gibi bir ortam simüle ediyoruz. Oracle,Sql,Postgres vs. veri tabanlarından geliyormus gibi Simüle edildi
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Kalem",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Masa",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="NoteBook",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="KLavye",UnitPrice=150,UnitsInStock=65},
                 new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1}

            }; 
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); ****normalde bir listeden eleman bu kodlar silinir ama suan bu kodla silinmez.****
            //NEDENİ:arayüzden gönderilen productın bilgilerin aynı olması önemli değildir Heap te 5 tane adres vardır 
            //ÇÖZÜM : ID ler herzaman farklıdır onlardan yararlanarak silebiliriz bunun için foreach  döngüsünden yararlanalım ya da LINQ 

            //*********ÇÖZÜM 1***********
           // Product ProductToDelete = null;
            //foreach (var P in _products)
            //{                                            //Listeyi dolaşıp şart koyarak Yeni bir referans atıyoruz
            //    if (product.ProductId == P.ProductId)
            //    {
            //        ProductToDelete = P;    
            //    }
            //}

            //*********ÇÖZÜM 2 *************

              //LINQ - Language Integrate Query
            //LINQ ile yazıladabilir  (P=>P.ProductId == product.ProductId) == Forecah la aynı mantıkta ilerler 
           Product ProductToDelete= _products.SingleOrDefault(P=>P.ProductId == product.ProductId);

            _products.Remove(ProductToDelete);


        }

      /**/  public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

       /**/ public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderilen ürün ID 'sine sahip olan listede ki ürünü bul
            Product ProductToUpdate = _products.SingleOrDefault(P => P.ProductId == product.ProductId);
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.CategoryId = product.CategoryId;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;
            ProductToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
