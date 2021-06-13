using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodlarını yazarız 
            return new SuccessDataResult<List<Category>> (_categoryDal.GetAll(),Messages.ProductListed);
        }

        //select * from Categories where CategoryId = 3 
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

        public IDataResult<List<Category>> GetCategory()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.MaintenanceTime);
        }
    }
}
