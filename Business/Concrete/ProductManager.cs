using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService; // baska bir tablonun dal ile ile değil service ile cagrılmalı

      

        //[LogAspect] --->AOP
        //[Validate]
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
           

        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductsNameExists(product.ProductName), CheckIfProductCountOfCategoryCorrent(product.CategoryId),CheckIfCategoryLimitExceded()); //iş kuralları 

            if (result != null) //kurala uymayan bir durum varsa 
            {
                return result;
            }


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);  //kurala uyanları ekle 



        }

        public IResult DeleteProduct(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)  //ürün listelenmesini kapatmak isteyen bir kod 
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); //bakımda 
            }

            //İş kodları ?

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
            //succesdata result içinde bir list pproduct var ve onu ctorla parantez içindeki kosulları gönderiyoruz
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int Pid)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == Pid));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max)); //iki fiyat aralıgında olan veriyi getir
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)  //ürün listelenmesini kapatmak isteyen bir kod 
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            //? iş kuralı 
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GetProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.MaintenanceTime);
        }

        public IResult UpdateProduct(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        //iş kuralı oldugu için  private olması lazım çunku sadece bu classta çalıscak 
        private IResult CheckIfProductCountOfCategoryCorrent(int categoryId)  //Bir kategoride en fazla 10 ürün olabilir 
        {

            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CategoryDontListed);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductsNameExists(string productName) //aynı üründe isim eklenemez 
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //sarta uyan kayıt var mı ? 
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlReadyExists);
            }
            return new SuccessResult();
        }

        //mevcut categori sayısı 15 geçtiyse sisteme yeni ürün ekleme 
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >15)
            {
               
                return new ErrorResult(Messages.CategoryLimitExcededs);
            }
            return new SuccessResult();
            
        }
    }
}
