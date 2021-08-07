using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //hepsini IDataResult çevirdik
        // data product voidlerde data olmadıgı ıresult listlerde ıdataresult
        IDataResult<List<Product>> GetAll();  //hem işlem sonucu hemde mesajı içeren hemde data içersin T türünde  

        //List<Product> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int Pid);
        IResult AddProduct(Product product); //result donduruyo sonuc mesajı için 
        IResult DeleteProduct(Product product); 
        IResult AddTransactionalTest(Product product); 
        IResult UpdateProduct(Product product);

        IDataResult<List<Product>> GetProducts();
    }
}
