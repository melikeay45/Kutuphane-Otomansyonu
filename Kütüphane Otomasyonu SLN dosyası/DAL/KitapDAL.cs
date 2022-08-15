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
    public class KitapDAL              //Diğer classlardan erişebilmek için KitapDAL classını public yaptım.
    {

        public static bool kitapSorgu(KitapVeri kitap)   // Id si girilen kitabın veritabanında kayıtlı olup olmadığını kontrol eden Entity katmanının KitapVeri sınıfından oluşan 
                                                         // kitap nesnesini parametre alan bool veri tipinde değer döndüren bir fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Kitap where KitapId=@KitapId", Baglanti.baglanti);  // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan KitapId alanı,
            // girilen kitabın id si ile eşleşen kayıtları getiren sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını, command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            
            Baglanti.Connection(command);  // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);    // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.

            OleDbDataReader okuma = command.ExecuteReader();          // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okuyup 
                                                                      //OleDbDataReader class ından oluşturduğum okuma nesnesine atar.
            
            bool sonuc = false;     // bool tipinde sonuc değişkenini tanımladım ve false değerini atadım.
            
            int sayac = 0;          // intreger tipinde sayac değişkenini tanımladım ve 0 değerini atadım.

            while (okuma.Read())    // okuma nesnesinin read fonksiyonu true döndürdüğü sürece yani okuma nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;            // while döngüsü döndüğü sürece sayaç bir artar. Ve sorgu sonucunda kaç tane değer geldiğini sayar. 
            }


            if (sayac > 0)         // Sorgu sonucundan en az bir değer gelmişse yani sayaç>0 ise 
            {
                sonuc = true;      //sonuc değişkenine true değeri atanır. 
            }

            return sonuc;          // kitapSorgu fonksiyonunun çağrıldığı yere sonuc değişkenini döndürdüm.
        }



        public static int kitapEkle(KitapVeri kitap)   // Bilgileri girilen yeni kitabı veritabanına ekleyen Entity katmanının KitapVeri sınıfından oluşan 
                                                       // kitap nesnesini parametre alan integer veri tipinde değer döndüren bir fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("insert into Kitap(KitapAd,KitapTuru,KitapSayfa,KitapYazar) values(@KitapAd,@KitapTuru,@KitapSayfa,@KitapYazar)", Baglanti.baglanti);   // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının Kitap tablosuna yeni kitap ekleyen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını, command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);  // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapAd", kitap.KitapAd);         // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapTuru", kitap.KitapTuru);     // command nesnesindeki @KitapTuru parametresine, parametre olarak aldığımız kitap nesnesinin KitapTuru değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapSayfa", kitap.KitapSayfa);   // command nesnesindeki @KitapSayfa parametresine, parametre olarak aldığımız kitap nesnesinin KitapSayfa değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapYazar", kitap.KitapYazar);   // command nesnesindeki @KitapYazar parametresine, parametre olarak aldığımız kitap nesnesinin KitapYazar değişkeninin değerini Get özelliği ile atadım.

            return command.ExecuteNonQuery();    //KitapEkle fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }


        
        public static List<KitapVeri> kitapListe()    // Veri tabanındaki kitapları listeleyen parametre almayan ve List<T> sınıfından oluşturulmuş KitapVeri class ı türünde verileri tutan listeyi döndüren 
                                                      //fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Kitap", Baglanti.baglanti);    // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundaki kitapları
            // getiren sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);   // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            OleDbDataReader read = command.ExecuteReader();     // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                //OleDbDataReader class ından oluşturduğum read nesnesine atar.
           
            List<KitapVeri> kitap = new List<KitapVeri>();     // KitapVeri classının nesnelerini liste şeklinde tutan List<KitapVeri> class ından nesne oluşturdum.

            while (read.Read())       // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                kitap.Add(new KitapVeri     // kitap listesine Add fonksiyonu ile KitapVeri türünde yeni nesne ekler.
                {
                    KitapId = int.Parse(read["KitapId"].ToString()),      // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapId değerini alıp intreger e çevirdim ve KitapVeri classının nesnesinin KitapId değişkenine atadım.
                    KitapAd = read["KitapAd"].ToString(),                 // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapAd değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                    KitapTuru = read["KitapTuru"].ToString(),             // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapTuru değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                    KitapSayfa = read["KitapSayfa"].ToString(),           // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapSayfa değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                    KitapYazar = read["KitapYazar"].ToString()            // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapYazar değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                });
            }

            return kitap;    //kitapListe fonksiyonunun çağrıldığı yere kitap listesini döndürdüm.
        }



        public static int kitapSil(KitapVeri kitap)     //Veritabanındaki kitap tablosundaki kayıtlardan KitapId alanı, girilen KitapId ile aynı olan kaydı silen KitapVeri classından üretilen nesne tipinde parametre alan ve integer tipinde 
                                                        //değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Delete from Kitap where KİtapId=@KitapId ", Baglanti.baglanti);       // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan KitapId alanı,  
            // girilen KitapId alanı ile eşleşen kayıtları getiren sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını, command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.

            Baglanti.Connection(command);// Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.

            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);   // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.

            return command.ExecuteNonQuery();               //kitapSil fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }

        public static int kitapGuncelle(KitapVeri kitap)      //Veritabanındaki kitap tablosundaki kayıtlardan KitapId alanı, girilen KitapId ile aynı olan kaydın bilgilerini güncelleyen KitapVeri classından üretilen nesne tipinde parametre 
                                                              // alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Update Kitap set KitapAd=@KitapAd,KitapTuru=@KitapTuru,KitapSayfa=@KitapSayfa,KitapYazar=@KitapYazar where KitapId=@KitapId", Baglanti.baglanti);  // OleDbCommand class ından command nesnesini
            //oluşturdum. Veritabanının Kitap tablosunda kayıtlı kitabın bilgilerini güncelleyen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını, command nesnesinin OleDbCommand fonksiyonuna parametre olarak 
            // gönderdim.

            Baglanti.Connection(command); // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            command.Parameters.AddWithValue("@KitapAd", kitap.KitapAd);       // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapTuru", kitap.KitapTuru);   // command nesnesindeki @KitapTuru parametresine, parametre olarak aldığımız kitap nesnesinin KitapTuru değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapSayfa", kitap.KitapSayfa); // command nesnesindeki @KitapSayfa parametresine, parametre olarak aldığımız kitap nesnesinin KitapSayfa değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapYazar", kitap.KitapYazar); // command nesnesindeki @KitapYazar parametresine, parametre olarak aldığımız kitap nesnesinin KitapYazar değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);       // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
             
            return command.ExecuteNonQuery();      //kitapGuncelle fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }


        public static KitapVeri kitapIdBilgi(KitapVeri kitap)    //Veritabanındaki kitap tablosundaki kayıtlardan KitapId alanı, girilen KitapId ile aynı olan kaydın bilgilerini getiren KitapVeri classından üretilen nesne tipinde parametre alan ve KitapVeri tipinde 
                                                                 //değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Select * from Kitap where KitapId = @KitapId", Baglanti.baglanti);   // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan KitapId alanı,  
            // girilen KitapId alanı ile eşleşen kayıtları getiren sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını, command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            
            Baglanti.Connection(command);    // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);      // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
           
            OleDbDataReader read = command.ExecuteReader();         // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                    //OleDbDataReader class ından oluşturduğum read nesnesine atar.

            while (read.Read())         // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                kitap.KitapAd = read["KitapAd"].ToString();        // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapAd değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                kitap.KitapTuru = read["KitapTuru"].ToString();    // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapTuru değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                kitap.KitapSayfa = read["KitapSayfa"].ToString();  // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapSayfa değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
                kitap.KitapYazar = read["KitapYazar"].ToString();  // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapYazar değerini alıp KitapVeri classının nesnesinin KitapId değişkenine atadım.
            }

            return kitap;           //kitapIdBilgi fonksiyonunun çağrıldığı yere kitap nesnesini döndürdüm.
        }
    }
}

