using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Interface'in operasyonları publicdir ve kendisi public değildir o yüzden public yapıyoruz.

    //urun detayları ıcın joın ıcın ıproduct dal da operasyonları yazmak ıcın kullanlır 
    public interface IProductDal :IEntityRepository<Product>   //SEN Ientity reporisort product için yapılandırdın
        //Product la ilgili veri tabanında yapacagımız operasyonları(delete,update,add vs..) içeren interface.

    {
        List<ProductDetailDto> GetProductDetails();


    }
}
