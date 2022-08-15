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
    public class KitapIadeDAL              //Diğer classlardan erişebilmek için KitapIadeDAL classını public yaptım.
    {

        public static List<KitapOgrenciVeri> kitapOgrenciListe(KitapOgrenciVeri kitap)    // Id si girilen kitabı alanları listeleyen KitapOgrenciVeri class ından oluşturulan nesneyi parametre alan ve List<T> sınıfından oluşturulmuş 
                                                                                          // KitapOgrenciVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap, kitapkayıt ve Ogrenci tablosundan istenen alanları inner join yöntemi ile getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select k.KitapId,o.OgrenciAd,o.OgrenciSoyad,k.KitapAd,kk.KitapAlinma,kk.KitapTeslim,kk.KitapKontrol from ((Kitap k inner join KitapKayit kk on k.KitapId=kk.KitapId) inner join Ogrenci o on o.OgrenciId=kk.OgrenciId) where k.KitapId = @KitapId", Baglanti.baglanti);
           
            Baglanti.Connection(command);   // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
           
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);   // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
           
            OleDbDataReader read = command.ExecuteReader();      // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                 //OleDbDataReader class ından oluşturduğum read nesnesine atar.
            
            List<KitapOgrenciVeri> kitapOgrenci = new List<KitapOgrenciVeri>();         // KitapOgrenciVeri classının nesnelerini liste şeklinde tutan List<KitapOgrenciVeri>  class ından nesne oluşturdum.

            while (read.Read())            // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                kitapOgrenci.Add(new KitapOgrenciVeri          //kitapOgrenci listesine Add fonksiyonu ile KitapOgrenciVeri türünde yeni nesne ekledim.
                {
                    KitapId = int.Parse(read["KitapId"].ToString()),      // Read fonksiyonunun read değişkeninde okuduğu kaydın KitapId değerini alıp intreger e çevirdim ve KitapOgrenciVeri classının nesnesinin KitapId değişkenine atadım.
                    OgrenciAd = read["OgrenciAd"].ToString(),             // Read fonksiyonunun read değişkeninde okuduğu kaydın OgrenciAd değerini alıp KitapOgrenciVeri classının nesnesinin OgrenciAd değişkenine atadım.
                    OgrenciSoyad = read["OgrenciSoyad"].ToString(),       // Read fonksiyonunun read değişkeninde okuduğu kaydın OgrenciSoyad değerini alıp KitapOgrenciVeri classının nesnesinin OgrenciSoyad değişkenine atadım.
                    KitapAd = read["KitapAd"].ToString(),                 // Read fonksiyonunun read değişkeninde okuduğu kaydın KitapAd değerini alıp KitapOgrenciVeri classının nesnesinin KitapAd değişkenine atadım.
                    KitapAlinma = DateTime.Parse(read["KitapAlinma"].ToString()),    // Read fonksiyonunun read değişkeninde okuduğu kaydın KitapAlinma değerini alıp DateTiem veri tipine çevirdim ve KitapOgrenciVeri classının nesnesinin KitapAlinma değişkenine atadım.
                    KitapTeslim = read["KitapTeslim"].ToString(),         // Read fonksiyonunun read değişkeninde okuduğu kaydın KitapTeslim değerini alıp KitapOgrenciVeri classının nesnesinin KitapTeslim değişkenine atadım.
                    KitapKontrol = bool.Parse(read["KitapKontrol"].ToString())   // Read fonksiyonunun read değişkeninde okuduğu kaydın KitapKontrol değerini alıp bool veri tipine çevirdim ve KitapOgrenciVeri classının nesnesinin KitapKontrol değişkenine atadım.
                });
            }

            return kitapOgrenci;    //kitapOgrenciListe fonksiyonunun çağrıldığı yere kitapOgrenci listesini döndürdüm.
        }


        public static List<AlinanKitapVeri> ogrenciIdListe(AlinanKitapVeri kitap)    // Id si girilen öğrencinin aldığı kitapları tarihleri ile listeleyen AlinanKitapVeri class ından oluşturulan nesneyi parametre alan ve List<T> sınıfından oluşturulmuş 
                                                                                     // AlinanKitapVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap, kitapkayıt ve Ogrenci tablosundan istenen alanları inner join yöntemi ile getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select o.OgrenciId,k.KitapAd,kk.KitapAlinma,kk.KitapTeslim,kk.KitapKontrol from ((Kitap k inner join KitapKayit kk on k.KitapId=kk.KitapId) inner join Ogrenci o on o.OgrenciId=kk.OgrenciId) where o.OgrenciId = @OgrenciId", Baglanti.baglanti);
            
            Baglanti.Connection(command);    // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.

            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);    // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();   // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                              //OleDbDataReader class ından oluşturduğum read nesnesine atar.
            
            List<AlinanKitapVeri> kitapOgrenci = new List<AlinanKitapVeri>();      // AlinanKitapVeri classının nesnelerini liste şeklinde tutan List<AlinanKitapVeri>  class ından nesne oluşturdum.
           
            while (read.Read())       // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                kitapOgrenci.Add(new AlinanKitapVeri          //kitapOgrenci listesine Add fonksiyonu ile AlinanKitapVeri türünde yeni nesne ekler.
                {
                    OgrenciId = int.Parse(read["OgrenciId"].ToString()),    // Read fonksiyonunun read nesnesine okuduğu kaydın OgrenciId değerini alıp intreger e çevirdim ve AlinanKitapVeri classının nesnesinin OgrenciId değişkenine atadım.
                    KitapAd = read["KitapAd"].ToString(),                   // Read fonksiyonunun read nesnesine okuduğu kaydın KitapAd değerini alıp AlinanKitapVeri classının nesnesinin KitapAd değişkenine atadım.
                    KitapAlinma = DateTime.Parse(read["KitapAlinma"].ToString()),     // Read fonksiyonunun read nesnesine okuduğu kaydın KitapAlinma değerini alıp DateTiem veri tipine çevirdim ve AlinanKitapVeri classının nesnesinin KitapAlinma değişkenine atadım. 
                    KitapTeslim = read["KitapTeslim"].ToString(),           // Read fonksiyonunun read nesnesine okuduğu kaydın KitapTeslim değerini alıp AlinanKitapVeri classının nesnesinin KitapTeslim değişkenine atadım.
                    KitapKontrol = bool.Parse(read["KitapKontrol"].ToString())        // Read fonksiyonunun read nesnesine okuduğu kaydın KitapKontrol değerini alıp bool veri tipine çevirdim ve AlinanKitapVeri classının nesnesinin KitapKontrol değişkenine atadım.
                });
            }

            return kitapOgrenci;      //ogrenciIdListe fonksiyonunun çağrıldığı yere kitapOgrenci listesini döndürdüm.
        }

        //Alinabilir durumdaki kitapların teslim edilme durumlarına göre listeleme işlemi gerçekleştirildi
        public static List<string> kitapAlinanListe(KitapIadeVeri kitap)      // Id si girilen öğrencinin aldığı kitapları teslim edip etmediği bilgisine göre listeleyen KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve 
                                                                              // List<T> sınıfından oluşturulmuş string tipinde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan Id si girilen öğrencinin almadığı ve KitapKontrol değeri true olan yani teslim edilen kitapların adını getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select KitapAd from Kitap where KitapId not in(select KitapId from KitapKayit where OgrenciId=@OgrenciId and KitapKontrol=false)", Baglanti.baglanti);
           
            Baglanti.Connection(command);        // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);   // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();    // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                               //OleDbDataReader class ından oluşturduğum read nesnesine atar.

            List<string> liste = new List<string>();            // string tipinde verileri liste şeklinde tutan List<string>  class ından nesne oluşturdum.

            while (read.Read())       // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                liste.Add(read["KitapAd"].ToString());    // Read fonksiyonunun read nesnesinde okuduğu kaydın OgrenciAd değerini liste ye ekledim.
            }

            return liste;    //kitapAlinanListe fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        }

        //Teslim edilmesi gereken kitaplar teslim edilmeme durumuna göre listeye aktarıldı
        public static List<string> kitapTeslimListe(KitapIadeVeri kitap)    // Teslim edilmesi gerek kitapları listeleyen KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve 
                                                                            // List<T> sınıfından oluşturulmuş string tipinde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan Id si girilen öğrencinin aldığı ve KitapKontrol değeri false olan yani teslim edilmeyen kitapların adını getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select KitapAd from Kitap where KitapId in(select KitapId from KitapKayit where OgrenciId=@OgrenciId and KitapKontrol=false)", Baglanti.baglanti);
            
            Baglanti.Connection(command);       // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);    // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();            // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                       //OleDbDataReader class ından oluşturduğum read nesnesine atar.
                                                                        
            List<string> liste = new List<string>();             // string tipinde verileri liste şeklinde tutan List<string>  class ından nesne oluşturdum.

            while (read.Read())                               // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                liste.Add(read["KitapAd"].ToString());        // Read fonksiyonunun read değişkeninde okuduğu kaydın OgrenciAd değerini liste ye ekledim.
            }
                         
            return liste;                                     //kitapTeslimListe fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        } 

        //Öğrenciye verilmiş kitapların sayısı int olarak döndürüldü
        public static int grafikVerilmis(KitapIadeVeri kitap)   //Öğrenciye verilen kitapların sayısını döndüren KitapIadeVeri class ının nesnesini parametre alan integer tipinde veri döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan Id si girilen öğrencinin aldığı ve KitapKontrol değeri false olan yani teslim edilmeyen kitapların adını getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select KitapAd from Kitap where KitapId in(select KitapId from KitapKayit where OgrenciId=@OgrenciId and KitapKontrol=false)", Baglanti.baglanti);
            
            Baglanti.Connection(command);     // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);   // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();   // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                              //OleDbDataReader class ından oluşturduğum read nesnesine atar.
            int sayac = 0;             //intriger tipinde değişken tanımlayıp 0 değerini atadım.
            while (read.Read())         // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;                //read nesnesindeki kayıt sayısı kadar sayac arttı.
            }

            return sayac;             //grafikVerilmis fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        }

        //Tüm kitapların sayısı int olarak döndürüldü
        public static int grafikHepsi()    // Tüm kitapların sayısını döndüren parametre almayan ve integer tipinde veri döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundaki bütün kitapları getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select * from Kitap", Baglanti.baglanti);  
            
            Baglanti.Connection(command);   // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            OleDbDataReader read = command.ExecuteReader();       // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                  //OleDbDataReader class ından oluşturduğum read nesnesine atar.
            int sayac = 0;                // intriger tipinde değişken tanımlayıp 0 değerini atadım.
            while (read.Read())           // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;                  //read nesnesindeki kayıt sayısı kadar sayac arttı.
            }

            return sayac;                //grafikVerilmis fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        }

        //Alınabilir kitapların sayısı int olarak döndürüldü
        public static int grafikAlinabilir(KitapIadeVeri kitap)    //Ogrencinin alabileceği kitapların sayısını döndüren KitapIadeVeri class ının nesnesini parametre alan integer tipinde veri döndüren fonksiyon yazdım.
        {

            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap tablosundan Id si girilen öğrencinin almadığı ve KitapKontrol değeri true olan yani teslim edilen kitapların adını getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select KitapAd from Kitap where KitapId not in(select KitapId from KitapKayit where OgrenciId=@OgrenciId and KitapKontrol=false)", Baglanti.baglanti);
            
            Baglanti.Connection(command);         // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);     // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();     // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                //OleDbDataReader class ından oluşturduğum read nesnesine atar.
            int sayac = 0;            // intriger tipinde değişken tanımlayıp 0 değerini atadım.
            while (read.Read())        // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                sayac++;              //read nesnesindeki kayıt sayısı kadar sayac arttı.
            }

            return sayac;               //grafikAlinabilir fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        }

        public static List<string> kitapTarih(KitapIadeVeri kitap)   // Kitabın alınma tarihini getiren KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve 
                                                                     // List<T> sınıfından oluşturulmuş string tipinde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının KitapKyit tablosundan OgrenciId si girilen OgrenciId si ile  ve KitapId sigirilen KitapId ile aynı olan  
            // kitapların KitapAlinma alanını getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select KitapAlinma from KitapKayit where KitapId=@KitapId and OgrenciId=@OgrenciId", Baglanti.baglanti);
            
            Baglanti.Connection(command);    // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);       // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
            
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);      // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();      // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                 //OleDbDataReader class ından oluşturduğum read nesnesine atar.

            List<string> liste = new List<string>();     // string tipinde verileri liste şeklinde tutan List<string>  class ından nesne oluşturdum.

            while (read.Read())            // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {
                kitap.KitapAlinma = DateTime.Parse(read["KitapAlinma"].ToString());   //kitap parammetresinin KitapAlinma değişkenine 
                                                                                      //Read fonksiyonunun read nesnesindeki okuduğu satırın KitapAlinma değerini Set özelliği ile atadım.
            }

            return liste;      //kitapTarih fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        }


        //Veritabanından öğrenciye ait ceza bilgisi listeye aktarıldı
        public static List<string> OgrenciCeza(KitapIadeVeri kitap)         // Id si verilen öğrencinin cezasını getiren KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve 
                                                                            // List<T> sınıfından oluşturulmuş string tipinde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Kitap, kitapkayıt ve Ogrenci tablosundan istenen alanları inner join yöntemi ile getiren sorguyu ve Baglanti class ının baglanti değişkenini yani 
            // veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select o.OgrenciCeza from ((Kitap k inner join KitapKayit kk on k.KitapId=kk.KitapId) inner join Ogrenci o on o.OgrenciId=kk.OgrenciId) where o.OgrenciId = @OgrenciId", Baglanti.baglanti);
            
            Baglanti.Connection(command);      // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.

            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);    // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.

            OleDbDataReader read = command.ExecuteReader();       // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                  //OleDbDataReader class ından oluşturduğum read nesnesine atar.

            List<string> liste = new List<string>();              // string tipinde verileri liste şeklinde tutan List<string>  class ından nesne oluşturdum.

            while (read.Read())                   // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner
            {
                kitap.OgrenciCeza = float.Parse(read["OgrenciCeza"].ToString());   //kitap parammetresinin OgrenciCeza değişkenine Read fonksiyonunun read nesnesindeki okuduğu satırın OgrenciCeza değerini Set metodu ile atadım.
            }

            return liste;      //OgrenciCeza fonksiyonunun çağrıldığı yere liste listesini döndürdüm.
        }

        //Ceza işlemi gerçekleştirildikten sonra ogrenciye ait ceza verisinde guncelleme yapıldı
        public static int ogrenciCezaIslemi(KitapIadeVeri ogrenci)         // Id si verilen öğrencinin ceza bilgisini güncelleyen KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("Update Ogrenci set OgrenciCeza=@OgrenciCeza where OgrenciId=@OgrenciId", Baglanti.baglanti);   // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının Ogrenci tablosunda 
            // girilen id değeri ile eşleşen öğrencinin OgrenciCeza alanını güncelleyen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
           
            Baglanti.Connection(command);      // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.

            command.Parameters.AddWithValue("@OgrenciCeza", ogrenci.OgrenciCeza);    // command nesnesindeki @OgrenciCeza parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciCeza değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciId", ogrenci.OgrenciId);        // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.

            return command.ExecuteNonQuery();       //ogrenciCezaIslemi fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }



        //Kitap alındğında veri tabanına veriler eklendi
        public static int kitapAlimIslemi(KitapIadeVeri kitap)  // Ogrencilerin aldığı kitabı KitapKayit tablosuna ekleyen KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve intreger veri tipinde değer döndüren fonksiyon yazdım.
        {
            OleDbCommand command = new OleDbCommand("insert into  KitapKayit(KitapId,OgrenciId,KitapAlinma) values(@KitapId,OgrenciId,@KitapAlinma)", Baglanti.baglanti);   // OleDbCommand class ından command nesnesini oluşturdum.
            //Veritabanının KitapKayit tablosuna yeni kitap ekleyen sorguyu ve Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını, command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            
            Baglanti.Connection(command);      // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);             // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);         // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapAlinma", kitap.KitapAlinma);     // command nesnesindeki @KitapAlinma parametresine, parametre olarak aldığımız kitap nesnesinin KitapAlinma değişkeninin değerini Get özelliği ile atadım.
           
            return command.ExecuteNonQuery();                                       //kitapAlimIslemi fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }

        //Kitap teslim edildiğinde veriler güncellendi
        public static int kitapTeslimIslemi(KitapIadeVeri kitap)   //Teslim edilen kitabın KitapKayit tablosundaki kaydını güncelleyen KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve intreger veri tipinde değer döndüren fonksiyon yazdım.
        {

            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının KitapKayit tablosunda girilen KitapId değeri ve  OgrenciId değeri eşleşen kaydın bilgilerini güncelleyen sorguyu ve 
            // Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Update KitapKayit set KitapTeslim=@KitapTeslim,KitapKontrol=@KitapKontrol where KitapId=@KitapId  and  OgrenciId=@OgrenciId", Baglanti.baglanti);  
            
            Baglanti.Connection(command);       // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapTeslim", kitap.KitapTeslim);    // command nesnesindeki @KitapTeslim parametresine, parametre olarak aldığımız kitap nesnesinin KitapTeslim değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapKontrol", kitap.KitapKontrol);  // command nesnesindeki @KitapKontrol parametresine, parametre olarak aldığımız kitap nesnesinin KitapKontrol değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@KitapId", kitap.KitapId);            // command nesnesindeki @KitapId parametresine, parametre olarak aldığımız kitap nesnesinin KitapId değişkeninin değerini Get özelliği ile atadım.
            command.Parameters.AddWithValue("@OgrenciId", kitap.OgrenciId);        // command nesnesindeki @OgrenciId parametresine, parametre olarak aldığımız kitap nesnesinin OgrenciId değişkeninin değerini Get özelliği ile atadım.
          
            return command.ExecuteNonQuery();                                      //kitapTeslimIslemi fonksiyonunun çağrıldığı yere sorgudan etkilenen satır sayısını döndürdüm.
        }


        //Kitap adı sorgusu ile ada ait kitapId verisi int döndürüldü
        public static int kitapId(KitapOgrenciVeri kitap)   //İsmi girilen kitabın KitapId değerini döndüren KitapIadeVeri class ından oluşturulan nesneyi parametre alan ve intreger veri tipinde değer döndüren fonksiyon yazdım.
        {

            // OleDbCommand class ından command nesnesini oluşturdum. Veritabanının kitap tablosundan girilen KitapAd değeri kitap tablosunda eşleşen kaydın KitapId alanını getiren sorguyu ve 
            // Baglanti class ının baglanti değişkenini yani veritabanı bağlantısını command nesnesinin OleDbCommand fonksiyonuna parametre olarak gönderdim.
            OleDbCommand command = new OleDbCommand("Select KitapId from Kitap where KitapAd=@KitapAd", Baglanti.baglanti);   

            Baglanti.Connection(command);      // Bağlantı class ının Connection fonksiyonuna command nesnesini gönderip bağlantının açık olup olmadığını kontrol ettirdim. Bağlantı açık değilse açtırdım.
            
            command.Parameters.AddWithValue("@KitapAd", kitap.KitapAd);     // command nesnesindeki @KitapAd parametresine, parametre olarak aldığımız kitap nesnesinin KitapAd değişkeninin değerini Get özelliği ile atadım.
            
            OleDbDataReader read = command.ExecuteReader();        // OleDbCommand class ından oluşturduğum command nesnesinin ExecuteReader fonksiyonu ile sorgu sonuçlarını okur 
                                                                   //OleDbDataReader class ından oluşturduğum read nesnesine atar.

            int id = 0;     // integer tipinde değişken oluşturdum ve değişkene 0 değerini atadım.
           
            while (read.Read())   // read nesnesinin Read fonksiyonu true döndürdüğü sürece yani read nesnesinde sorgu sonucundan gelen değerler olduğu sürece while döngüsü döner.
            {

                id = int.Parse(read["KitapId"].ToString());      // Read fonksiyonunun read nesnesinde okuduğu kaydın KitapId alanını id değişkenine atadım.
            }

            return id;       //kitapId fonksiyonunun çağırıldığı yere id değişkeninin değerini döndürdüm.


        }
    }
}

