using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;  // Access veri tabanı kütüphanesini ekledim.
using System.Data;        // Bazı sınıfları kullanmak için gerekli kütüphaneyi ekledim.
using Entity;             // Entity katmanını kullanmak için ekledim.

namespace DAL
{
    public class GorevliDAL       //Diğer classlardan erişebilmek için GorevliDAL classını public yaptım.
    {
        public static bool gorevliKontrol(GorevliVeri gorevli)  //Giriş yapmak isteyen görevlinin sistemde kayıtlı olup olmadığını kontrol eden 
                                                                //Entity katmanındaki GörevliVeri class ından oluşturulan nesneyi parametre alan bool tipinde değer veri döndüren fonksiyon yazdım.
        {

            OleDbCommand command = new OleDbCommand("Select * from Gorevli where GorevliTc=@gorevTc and GorevliSifre=@gorevSifre", Baglanti.baglanti);  // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının Görevli tablosundan GörevliTc alanı, girilen tc ile eşleşen ve GorevliSifre alanı, girilen sifre ile eşleşen kayıtları getiren sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            
            Baglanti.Connection(command);  // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            command.Parameters.AddWithValue("@gorevTc", gorevli.gorevTc);  // command nesnesindeki @GorevliTc parametresine, parametre olarak aldığımız gorevli nesnesinin gorevliTc değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@gorevSifre", gorevli.gorevSifre);  // command nesnesindeki @GorevliSifre parametresine, parametre olarak aldığımız gorevli nesnesinin gorevliSifre değişkeninin değerini Get özelliği ile atadım.

            OleDbDataReader okuma = command.ExecuteReader();  // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okurtup 
                                                              //OleDbDataReader class ından oluşturduğum okuma nesnesine atadım.
            bool sonuc = false;  // bool tipinde sonuc değişkenini tanımladım ve false değerini atadım.
            int sayac = 0;   // integer tipinde sayac değişkenini tanımladım ve 0 değerini atadım.

            while (okuma.Read())   // okuma nesnesinin read fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;  // while döngüsü döndüğü sürece sayaç bir artar. Ve sorgu sonucunda kaç tane değer geldiğini sayar.
            }


            if (sayac > 0)  // Sorgu sonucundan en az bir değer gelmişse yani sayaç>0 ise 
            {
                sonuc = true;  //sonuc değişkenine true değeri atanır.
            }

            return sonuc;   // gorevliKontrol fonksiyonunun çağrıldığı yere sonuc değişkenini dündürdüm.

        }
    }
}
