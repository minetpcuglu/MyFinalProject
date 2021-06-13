using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //-------ATTRIBUTE    // Java ------ ANNOTATION
    public class ProductsController : Controller
    {

        //Loosely coupled
        //naming convention
        //IoC Container --Inversion of Control ----container ihtiyacları verme de yardımcı olur 
        //dependency chain //bagımlılık zinciri 


        IProductService _productService; //field  default private

        public ProductsController(IProductService productService) //parantez içi manager ver demek 
        {
            _productService = productService;
        }

        [HttpGet("Get")]
        public List<Product> Get()

        {
           
            var result = _productService.GetAll();
            return result.Data;
        }


        //public ActionResult GetAll()
        //{
        //   var result =  _productDal.GetAll();
        //    return Ok(result);
        //}
    }
}
