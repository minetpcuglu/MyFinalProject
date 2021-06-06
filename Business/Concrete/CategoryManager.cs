using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //exception  //bagımlıgımızı const ıncktion ile yapıyoruz 
        ICategoryDal _categoryDal;  //ampulden constructer yap 

        public CategoryManager(ICategoryDal categoryDal)
        {
           _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodlarını yazarız 
            return _categoryDal.GetAll();
        }

        //select * from Categories where CategoryId = 3 
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
