using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants //sabit demek
{
    public static class Messages   //statik verildği zaman newlenmez oyuzden statik yapıldı 
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string CategoryAdded = "Kategori Eklendi";
        public static string CategoryDeleted = "Kategori Silindi";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string CategoryNameInValid = "Kategori ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string CategoryListed = "Kategoriler Listelendi";
        public static string CategoryDontListed = "Kategorilerde en fazla 10 ürün olabilir";
        public static string ProductNameAlReadyExists = "Böyle bir ürün zaten mevcut";
        public static string CategoryLimitExcededs = "Kategori ekleme limiti aşıldı";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered ="Kayıt olundu";
        public static string UserNotFound ="Kullanıcı bulunamadı";
        public static string PasswordError ="Hatalı şifre";
        public static string SuccessfulLogin ="Giriş başarılı";
        public static string UserAlreadyExists ="Kullanıcı mevcut";
        public static string AccessTokenCreated ="Token  oluşturuldu";
    }
}
