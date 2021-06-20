using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Validation;
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
        ICategoryDal _categoryDal; 

        public CategoryManager(ICategoryDal categoryDal)
        {
           _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof (CategoryValidator))]
        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodlarını yazarız 
            return new SuccessDataResult<List<Category>> (_categoryDal.GetAll(),Messages.CategoryListed);
        }

      
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

       
        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
