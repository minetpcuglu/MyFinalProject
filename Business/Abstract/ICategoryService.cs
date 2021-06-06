using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //kategori ile ilgili dıs dunyaya neyi servis etmek istiyorsak buraya yazıyoruz 
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);

    }
}
