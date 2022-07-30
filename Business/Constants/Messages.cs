using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNameInvalid = "Ara ismi geçersiz";
        public static string CarDetailEnlarged = ("Araç detayı getirildi");
        public static string CarListed = "Arabalar listelendi";

        public static string BrandAdded = ("Model eklendi");
        public static string BrandDeleted = ("Model silindi");
        public static string BrandUpdated = ("Model güncellendi");
        public static string BrandsListed = ("Modeller Listelendi");

        public static string ColorAdded = ("Renk eklendi");
        public static string ColorDeleted = ("Renk silindi");
        public static string ColorUpdated = ("Renk güncellendi");
        public static string ColorsListed = ("Renkler Listelendi");

        public static string UserAdded = ("Kullanıcı eklendi");
        public static string UserDeleted = ("Kullanıcı silindi");
        public static string UserUpdated = ("Kullanıcı güncellendi");
        public static string UsersListed = ("Kullanıcılar Listelendi");

        public static string CustomerAdded = ("Müşteri eklendi");
        public static string CustomerDeleted = ("Müşteri silindi");
        public static string CustomerUpdated = ("Müşteri güncellendi");
        public static string CustomersListed = ("Müşteriler Listelendi");

        public static string RentalAdded = ("Kiralama bilgisi eklendi");
        public static string RentalDeleted = ("Kiralama bilgisi silindi");
        public static string RentalUpdated = ("Kiralama bilgisi güncellendi");
        public static string RentalsListed = ("Kiralama bilgileri Listelendi");
        public static string CarIsOnRent = ("Araç şuan bir başkası tarafından kiralanmıştır");

        public  static string ImgUploadSuccessful="Resim başarıyla eklendi";
        public static string ImgRemoveSuccessful="Resim başarıyla silindi";
        public static string ImgUpadateSuccessful="Resim başarıyla güncellendi";

        public static string UserRegistered="Kayıt olundu";
        public static string UserNotFound="Böyle bir kullanıcı yok";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string AuthorizationDenied="Yetkiniz yok";
    }
}
