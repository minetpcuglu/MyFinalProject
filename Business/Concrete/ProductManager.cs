using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService  
    {
        IProductDal _productDal;

        //[LogAspect] --->AOP
        //[Validate]
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult AddProduct(Product product)  //
        {
            //business codes ? 
            

            if (product.ProductName.Length<2)
            {
                //magic string  string metinlerin olması onun yerine contants klasorunde mesaj sınıfı acıldı
                return new ErrorResult(Messages.ProductNameInValid);
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);    // result döndürdüğümüz için yapabilmemiz icin true ve mesajı constructer gerekir 
        }

        public IDataResult<List<Product>> GetAll()
        {
        //    if (DateTime.Now.Hour == 22)  //ürün listelenmesini kapatmak isteyen bir kod 
        //    {
        //        return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); //bakımda 
        //    }

            //İş kodları ?
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
            //succesdata result içinde bir list pproduct var ve onu ctorla parantez içindeki kosulları gönderiyoruz
        }
       

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));//benim gönderdiğim kategori ıd sine esitse onu filtrele 
        }

        public IDataResult<Product> GetById(int Pid)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == Pid));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice<=max)); //iki fiyat aralıgında olan veriyi getir
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)  //ürün listelenmesini kapatmak isteyen bir kod 
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime); //bakımda 
            }
            //? iş kuralı 
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GetProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.MaintenanceTime);
        }
    }
}
