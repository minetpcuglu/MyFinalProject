
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //IEntity mirası vermedik cunku prodyctdetaildto bir tablo değil
    public class ProductDetailDto:IDto //evrensel oldugu için core katmanında IDTO ekledik 
    {
        //Data Tranformation Object
        //DTO:ilişkisel veri tabanlarında ilişki ıdleri yerine isimlerini döndürmek (join operasyonları)

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }

    }
}
