using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //suan EfProductDalda butun operasyonları mevcut 
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            //join yazma
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products  //ürünlerle
                             join c in context.Categories  //kategorileri joinle 
                             on p.CategoryId equals c.CategoryId  //hangi kurala göre 
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };//hangi kolonları istiyorsun

                return result.ToList();

            }
        }
    }
}
