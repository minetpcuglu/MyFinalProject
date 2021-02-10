using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Interface'in operasyonları publicdir ve kendisi public değildir o yüzden public yapıyoruz.
    public interface IProductDal //Product la ilgili veri tabanında yapacagımız operasyonları(delete,update,add vs..) içeren interface.
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        // List<Product> GetAllByCategory(int categroyId);

        List<Product> GetAllByCategory(int categoryId);
    }
}
