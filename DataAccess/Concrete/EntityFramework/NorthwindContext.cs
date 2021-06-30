using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context = DB tabloları ile proje claslarına baglamak
   public class NorthwindContext:DbContext
    {
        // bu metot proje hangi veri tabaınında ilişkili oldugunu belirtilcek yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RKDCHFH;Database=Northwind;Trusted_Connection=true");  //sql kullanıcaz nasıl baglancaz belirtelim hangi veri tabanını baglancaz ? 
        }

        public DbSet<Product> Products { get; set; }   //hangi tablo hangi sınıfa baglancak bunu belirliyoruz
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }


}
