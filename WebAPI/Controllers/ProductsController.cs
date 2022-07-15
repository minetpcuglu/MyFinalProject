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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);  //postamndaki send 200 döndür demek 
            }
           return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Product p)
        {
            var result = _productService.AddProduct(p);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //public ActionResult GetAll()
        //{
        //   var result =  _productDal.GetAll();
        //    return Ok(result);
        //}
    }
}
