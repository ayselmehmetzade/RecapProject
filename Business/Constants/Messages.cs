using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string CarInvalid = "Ekleme işlemi başarısız. Lütfen bilgileri kontrol ediniz";
        public static string CarInvalid2 = "Güncelleme işlemi başarısız. Lütfen bilgileri kontrol ediniz";
        public static string CarDeleted = "Silme işlemi başarılı";
        public static string CarsListed = "Listelendi";
        public static string CarUpdated = "Güncelleme işlemi başarılı";
        public static string MaintenanceTime = "Bakım Zamanı";
        public static string CarCountColorError = "Bir arabanın en fazla 10 rengi olmalıdır";
        public static string CustomerLimitControl = "Müsteri Limiti Aşıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";



        public static string CarImageCountError = "İlgili Araç İçin Maksimum Resim Sayısına Ulaşıldı.";
        public static string ImageList = "Resimler Listelendi";
        public static string ListedByCarId = "Aracın resimleri getirildi.";
        public static string CarImage = "Araç resmi getirildi.";
        public static string ImageAdded = "Araç resmi eklendi.";
        public static string ImageUpdated = "Araç resmi güncellendi.";
        public static string ImageDeleted = "Araç resmi silindi..";

        public static string CarDetailList = "Listelendi";
    }

}