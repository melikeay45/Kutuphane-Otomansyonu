using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;         // Access veri tabanı kütüphanesini ekledim.
using System.Data;               // Bazı sınıfları kullanmak için gerekli kütüphaneyi ekledim.
using Entity;                    // Entity katmanını kullanmak için ekledim.
using System.Windows.Forms;

namespace DAL
{
    public class OgrenciDAL              //Diğer classlardan erişebilmek için OgrenciDAL classını public yaptım.
    {
        //Öğrencinin tabloda kayıtlı olma durumu kontrol edildi
        public static bool ogrenciKontrol(OgrenciVeri ogr)     // Girilen öğrenci numarası ve şifre ile eşleşen öğrencinin olup olmadığının kontrolünü yapan OgrenciVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Ogrenci where OgrenciNo=@OgrenciNo and OgrenciSifre=@OgrenciSifre", Baglanti.baglanti);  // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının Ogrenci tablosundan OgrenciNo alanı, girilen öğrenci numarası ile eşleşen ve OgrenciSifre alanı, girilen sifre ile eşleşen kayıtları getiren sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);      // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            command.Parameters.AddWithValue("@OgrenciNo", ogr.OgrenciNo);         // command nesnesindeki @OgrenciNo parametresine, parametre olarak aldığımız ogr nesnesinin OgrenciNo değişkeninin değerini Get metodu ile atadım.
            command.Parameters.AddWithValue("@OgrenciSifre", ogr.OgrenciSifre);   // command nesnesindeki @OgrenciSifre parametresine, parametre olarak aldığımız ogr nesnesinin OgrenciSifre değişkeninin değerini Get metodu ile atadım.

            OleDbDataReader okuma = command.ExecuteReader();     // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okutup 
                                                                 //OleDbDataReader class ından oluşturduğum okuma nesnesine atadım.
            bool sonuc = false;                 // bool tipinde sonuc değişkenini tanımladım ve false değerini atadım.
            int sayac = 0;                      // integer tipinde sayac değişkenini tanımladım ve 0 değerini atadım.

            while (okuma.Read())                // okuma nesnesinin read fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;                  // while döngüsü döndüğü sürece sayaç bir artar. Ve sorgu sonucunda kaç tane değer geldiğini sayar.
            }


            if (sayac > 0)             // Sorgu sonucundan en az bir değer gelmişse yani sayaç>0 ise 
            {
                sonuc = true;          //sonuc değişkenine true değeri atanır.
            }

            return sonuc;              // ogrenciKontrol fonksiyonunun çağrıldığı yere sonuc değişkenini dündürdüm.


        }


        public static bool OgrenciOkulNoKontrol(OgrenciVeri ogrenci)    //Yeni eklenecek öğrencinin öğrenci numarası veritabanında herhangi bir öğrencinin öğrenci numarası ile eşleşiyor mu kontrolünü yapan 
                                                                        //OgrenciVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select count(OgrenciNo) FROM Ogrenci Where OgrenciNo=@OgrenciNo", Baglanti.baglanti);  // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının Ogrenci tablosundan OgrenciNo alanı, girilen öğrenci numarası ile eşleşen kayıt sayısını getiren sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            
            Baglanti.Connection(command);     // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);    // command nesnesindeki @OgrenciNo parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciNo değişkeninin değerini Get metodu ile atadım.
            
            int count = Convert.ToInt32(command.ExecuteScalar());   // integer tipinde değişken tanımladım. ExecuteScalar() fonksiyonu ile command nesnesinden dönen ilk satırın ilk sütununun değerini integere çevirip count değişkenine atadım.

            if (count > 0)       //Eğer count değişkeninin değeri 0 dan büyükse yani girilen numaraya ait numara daha önce kayıtlıysa 
            {
                return false;    // OgrenciOkulNoKontrol fonksiyonunun çağrıldığı yere false değerini döndürdüm.
            }
            return true;         // OgrenciOkulNoKontrol fonksiyonunun çağrıldığı yere true değerini döndürdüm.

        }


        public static int ogrenciIdSorgu(OgrenciVeri ogr)      // Girilen öğrenci numarası ve şifreye ait öğrenci kaydının OgrenciId sini getiren OgrenciVeri classının nesnesini parametre alan ve intiger tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select OgrenciId from Ogrenci where OgrenciNo=@OgrenciNo and OgrenciSifre=@OgrenciSifre", Baglanti.baglanti);     // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının Ogrenci tablosundan OgrenciNo alanı, girilen öğrenci numarası ile eşleşen ve OgrenciSifre alanı, girilen sifre ile eşleşen kayıtların OgrenciId alanını getiren sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);     // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciNo", ogr.OgrenciNo);           // command nesnesindeki @OgrenciNo parametresine, parametre olarak aldığımız ogr nesnesinin OgrenciNo değişkeninin değerini Get metodu ile atadım.                                                                                            
            command.Parameters.AddWithValue("@OgrenciSifre", ogr.OgrenciSifre);     // command nesnesindeki @OgrenciSifre parametresine, parametre olarak aldığımız ogr nesnesinin OgrenciSifre değişkeninin değerini Get metodu ile atadım.

            OleDbDataReader okuma = command.ExecuteReader();  // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okutup 
                                                              //OleDbDataReader class ından oluşturduğum okuma nesnesine atadım.

            int id = 0;   //intiger tipinde değişken tanımladım ve 0 değerini atadım. 

            while (okuma.Read())          // okuma nesnesinin Read() fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                id = int.Parse(okuma["OgrenciId"].ToString());     // Read() fonksiyonunun okuma değişkeninde okuduğu kaydın OgrenciId değerini alıp intreger a çevirdim ve id değişkenine atadım.
            }
            return id;      // ogrenciIdSorgu fonksiyonunun çağrıldığı yere id değişkeninin değerini döndürdüm.
        }



        public static bool ogrenciSorgu(OgrenciVeri ogr)   // Id si girilen öğrencinin veritabanında kayıtlı olup olmadığının sorgusunu yapan OgrenciVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Ogrenci where OgrenciId=@OgrenciId", Baglanti.baglanti);  // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının Ogrenci tablosundan OgrenciId alanı, verilen id ile eşleşen kayıtları getiren sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);    // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciId", ogr.OgrenciId);     // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız ogr nesnesinin OgrenciId değişkeninin değerini Get metodu ile atadım.                                                                                            

            OleDbDataReader okuma = command.ExecuteReader();       // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okutup 
                                                                   //OleDbDataReader class ından oluşturduğum okuma nesnesine atadım.
           
            bool sonuc = false;                // bool tipinde sonuc değişkenini tanımladım ve false değerini atadım.
            int sayac = 0;                     // integer tipinde sayac değişkenini tanımladım ve 0 değerini atadım.

            while (okuma.Read())               // okuma nesnesinin Read() fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;                       // while döngüsü döndüğü sürece sayaç bir artar.Ve sorgu sonucunda kaç tane değer geldiğini sayar.
            }


            if (sayac > 0)              //Eğer sayac değeri 0 danbüyükse 
            {
                sonuc = true;           //sonuc değişkenine true değeri atanır.
            }

            return sonuc;               // ogrenciSorgu fonksiyonunun çağrıldığı yere sonuc değişkeninin değerini döndürdüm.


        }


        // Öğrenci tablosuna girilen öğrenci bilgileri eklendi
        public static int ogrenciEkle(OgrenciVeri ogrenci)    // Ogrenci tablosuna yeni öğrenci kaydı ekleyen OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Ogrenci tablosuna yeni öğrenci kaydını ekleyen sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("insert into Ogrenci(OgrenciAd,OgrenciSoyad,OgrenciNo,OgrenciSifre,OgrenciCinsiyet) values(@OgrenciAd,@OgrenciSoyad,@OgrenciNo,@OgrenciSifre,@OgrenciCinsiyet)", Baglanti.baglanti);
           
            Baglanti.Connection(command);    // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciAd", ogrenci.OgrenciAd);    // command nesnesindeki @OgrenciAd parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciAd değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciSoyad", ogrenci.OgrenciSoyad);   // command nesnesindeki @OgrenciSoyad parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciSoyad değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);         // command nesnesindeki @OgrenciNo parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciNo değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciSifre", ogrenci.OgrenciSifre);   // command nesnesindeki @OgrenciSifre parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciSifre değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciCinsiyet", ogrenci.OgrenciCinsiyet);   // command nesnesindeki @OgrenciCinsiyet parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciCinsiyet değişkeninin değerini Get özelliği ile atadım.

            return command.ExecuteNonQuery();    //ogrenciEkle fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }


        // İd ye ait öğrenci , Ogrenci tablosundan silindi
        public static int ogrenciSil(OgrenciVeri ogrenci)      //Id si girilen öğrencinin kaydını ogrenci tablosundan silen OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Delete from Ogrenci where OgrenciId=@OgrenciId ", Baglanti.baglanti);   // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Ogrenci tablosuna verilen OgrenciId ile eşleşen 
            //kaydı silen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
           
            Baglanti.Connection(command);     // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            command.Parameters.AddWithValue("@OgrenciId", ogrenci.OgrenciId);   // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.

            return command.ExecuteNonQuery();      //ogrenciSil fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }


        // Ogrenci Id ye ait bilgilerin güncellenme işlemi gerçekleştirildi
        public static int ogrenciGuncelle(OgrenciVeri ogrenci)   //Verilen Id ye ait öğrencinin bilgilerini güncelleyen OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {

            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Ogrenci tablosunda 
            // girilen id değeri ile eşleşen öğrencinin bilgilerini güncelleyen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Update Ogrenci set OgrenciAd=@OgrenciAd,OgrenciSoyad=@OgrenciSoyad,OgrenciNo=@OgrenciNo,OgrenciSifre=@OgrenciSifre,OgrenciCinsiyet=@OgrenciCinsiyet where OgrenciId=@OgrenciId", Baglanti.baglanti);
            
            Baglanti.Connection(command);            // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            command.Parameters.AddWithValue("@OgrenciAd", ogrenci.OgrenciAd);     // command nesnesindeki @OgrenciAd parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciAd değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciSoyad", ogrenci.OgrenciSoyad);    // command nesnesindeki @OgrenciSoyad parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciSoyad değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);          // command nesnesindeki @OgrenciNo parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciNo değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciSifre", ogrenci.OgrenciSifre);    // command nesnesindeki @OgrenciSifre parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciSifre değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciCinsiyet", ogrenci.OgrenciCinsiyet);    // command nesnesindeki @OgrenciCinsiyet parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciCinsiyet değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciId", ogrenci.OgrenciId);    // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
             
            return command.ExecuteNonQuery();   //ogrenciGuncelle fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }


        // Öğrenciye ait tüm bilgilerin listelenmesi gerçekleştirildi
        public static List<OgrenciVeri> liste()     // Ogrenci tablosundaki kayıtları listeleyen OgrenciVeri class ından oluşturulan parametre almayan ve List<T> sınıfından oluşturulmuş OgrenciVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Ogrenci", Baglanti.baglanti);    // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Ogrenci tablosundaki bütün kayıtları listeleyen sorguyu ve 
            //Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            
            Baglanti.Connection(command);           // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            OleDbDataReader read = command.ExecuteReader();           // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okutup 
                                                                      //OleDbDataReader class ından oluşturduğum okuma nesnesine atadım.
            List<OgrenciVeri> ogrenci = new List<OgrenciVeri>();      // OgrenciVeri classının nesnelerini liste şeklinde tutan List<OgrenciVeri>  class ından nesne oluşturdum.

            while (read.Read())                                       // read nesnesinin Read() fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                ogrenci.Add(new OgrenciVeri                            //ogrenci listesine Add fonksiyonu ile OgrenciVeri türünde yeni nesne eklerdim.
                {
                    OgrenciId = int.Parse(read["OgrenciId"].ToString()),    // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciId değerini alıp intreger e çevirdim ve OgrenciVeri classının nesnesinin OgrenciId değişkenine atadım.
                    OgrenciAd = read["OgrenciAd"].ToString(),               // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciAd değerini alıp OgrenciVeri classının nesnesinin OgrenciAd değişkenine atadım.
                    OgrenciSoyad = read["OgrenciSoyad"].ToString(),         // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciSoyad değerini alıp OgrenciVeri classının nesnesinin OgrenciSoyad değişkenine atadım.
                    OgrenciNo = read["OgrenciNo"].ToString(),               // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciNo değerini alıp  OgrenciVeri classının nesnesinin OgrenciNo değişkenine atadım.
                    OgrenciSifre = read["OgrenciSifre"].ToString(),         // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciSifre değerini alıp OgrenciVeri classının nesnesinin OgrenciSifre değişkenine atadım.
                    OgrenciCinsiyet = read["OgrenciCinsiyet"].ToString(),         // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciCinsiyet değerini alıp OgrenciVeri classının nesnesinin OgrenciCinsiyet değişkenine atadım.
                    OgrenciCeza = float.Parse(read["OgrenciCeza"].ToString())     // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciCeza değerini alıp OgrenciVeri classının nesnesinin OgrenciCeza değişkenine atadım.
                });
            }

            return ogrenci;     //liste fonksiyonunun çağrıldığı yere ogrenci listesini döndürdüm.
        }





        public static OgrenciVeri ogrenciIdBilgi(OgrenciVeri ogrenci)   //Id si verilen öğrencinin bilgilerini öğrenci tablosundan çeken OgrenciVeri classının nesnesini parametre alan ve OgrenciVeri classı tipinde veri döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Ogrenci where OgrenciId = @OgrenciId", Baglanti.baglanti);   // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Ogrenci tablosundaki verilen id ile OgrenciId eşleşen kayıtları 
            //listeleyen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);           // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciId", ogrenci.OgrenciId);       // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız ogrenci nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            OleDbDataReader read = command.ExecuteReader();            // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okutup 


            while (read.Read())                      // read nesnesinin Read() fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                ogrenci.OgrenciAd = read["OgrenciAd"].ToString();               // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciAd değerini alıp intreger e çevirdim ve ogrenci parametresinin OgrenciAd değişkenine atadım.
                ogrenci.OgrenciSoyad = read["OgrenciSoyad"].ToString();         // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciSoyad değerini alıp intreger e çevirdim ve ogrenci parametresinin OgrenciSoyad değişkenine atadım.
                ogrenci.OgrenciNo = read["OgrenciNo"].ToString();               // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciNo değerini alıp intreger e çevirdim ve ogrenci parametresinin OgrenciNo değişkenine atadım.
                ogrenci.OgrenciSifre = read["OgrenciSifre"].ToString();         // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciSifre değerini alıp intreger e çevirdim ve ogrenci parametresinin OgrenciSifre değişkenine atadım.
                ogrenci.OgrenciCinsiyet = read["OgrenciCinsiyet"].ToString();         // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciCinsiyet değerini alıp intreger e çevirdim ve ogrenci parametresinin OgrenciCinsiyet değişkenine atadım.
                ogrenci.OgrenciCeza = float.Parse(read["OgrenciCeza"].ToString());     // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciCeza değerini alıp intreger e çevirdim ve ogrenci parametresinin OgrenciCeza değişkenine atadım.
            }

            return ogrenci;          //ogrenciIdBilgi fonksiyonunun çağrıldığı yere ogrenci parametresini döndürdüm.
        }
    }
}
