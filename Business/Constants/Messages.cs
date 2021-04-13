using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Kaydı Başarıyla Eklendi.";
        public static string CarAddInvalid = "Hata! Araba Bilgilerini Kontrol Ediniz.";
        public static string CarDeleted = "Araba Kaydı Başarıyla Silindi.";
        public static string CarUpdated = "Araba Kaydı Başarıyla Güncellendi.";
        public static string CarListed = "Araba Kayıtları Başarıyla Listelendi.";
        public static string CarListInvalid = "Araba Kaydı Listeleme Başarısız.";


        public static string RentalAdded = "Kiralama Kaydı Başarıyla Eklendi.";
        public static string RentalAddInvalid = "Hata! Araç Zaten Kiralanmış Durumdadır.";
        public static string RentalDeleted = "Kiralama Kaydı Başarıyla Silindi.";
        public static string RentalUpdated = "Kiralama Kaydı Başarıyla Güncellendi.";
        public static string RentalListed = "Kiralama Kayıtları Başarıyla Listelendi.";
        public static string RentalListInvalid = "Kiralama Kaydı Listeleme Başarısız.";


        public static string UserAdded = "Kullanıcı Kaydı Başarıyla Eklendi.";
        public static string UserAddInvalid = "Hata! Kullanıcı Bilgilerini Kontrol Ediniz.";
        public static string UserDeleted = "Kullanıcı Kaydı Başarıyla Silindi.";
        public static string UserUpdated = "Kullanıcı Kaydı Başarıyla Güncellendi.";
        public static string UserListed = "Kullanıcı Kayıtları Başarıyla Listelendi.";
        public static string UserListInvalid = "Kullanıcı Kaydı Listeleme Başarısız.";


        public static string CustomerAdded = "Müşteri Kaydı Başarıyla Eklendi.";
        public static string CustomerAddInvalid = "Hata! Müşteri Bilgilerini Kontrol Ediniz.";
        public static string CustomerDeleted = "Müşteri Kaydı Başarıyla Silindi.";
        public static string CustomerUpdated = "Müşteri Kaydı Başarıyla Güncellendi.";
        public static string CustomerListed = "Müşteri Kayıtları Başarıyla Listelendi.";
        public static string CustomerListInvalid = "Müşteri Kaydı Listeleme Başarısız.";


        public static string ColorAdded = "Boya Kaydı Başarıyla Eklendi.";
        public static string ColorAddInvalid = "Hata! Boya Bilgilerini Kontrol Ediniz.";
        public static string ColorDeleted = "Boya Kaydı Başarıyla Silindi.";
        public static string ColorUpdated = "Boya Kaydı Başarıyla Güncellendi.";
        public static string ColorListed = "Boya Kayıtları Başarıyla Listelendi.";
        public static string ColorListInvalid = "Boya Kaydı Listeleme Başarısız.";


        public static string BrandAdded = "Marka Kaydı Başarıyla Eklendi.";
        public static string BrandAddInvalid = "Hata! Marka Bilgilerini Kontrol Ediniz.";
        public static string BrandDeleted = "Marka Kaydı Başarıyla Silindi.";
        public static string BrandUpdated = "Marka Kaydı Başarıyla Güncellendi.";
        public static string BrandListed = "Marka Kayıtları Başarıyla Listelendi.";
        public static string BrandListInvalid = "Marka Kaydı Listeleme Başarısız.";

        public static string CarImageLimitError = "Marka Kayıtları Başarıyla Listelendi.";
        public static string ImageIsNotFound = "Resim bulunamadı";
        public static string CarIsNotFound = "ARaba bulunamadı";
        public static string SuccessListed = "Başarıyla listelendi";
        public static string ErrorListed = "Listelenemedi";
        public static string SuccessUpdated = "Başarıyla güncellendi.";
        public static string SuccessDeleted = "Başarıyla silindi";
        public static string SuccessAdded = "Başarıyla eklendi";

        public static string CarImageLimitExceeded ="Resim Ekleme Limitine Ulaşıldı.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola yanlış";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserAlreadyExists = "Kayıtlı email!!";

        public static string AddedCarImage = "Resim Yüklendi";

        public static string DeletedCarImage { get; internal set; }
        public static string UpdatedCarImage { get; internal set; }
    }
}
