using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;      // DAL katmanını kullanmak için ekledim.
using Entity;   // Entity katmanını kullanmak için ekledim.

namespace BL
{
    public class KitapIadeBL     //Diğer classlardan erişebilmek için KitapBL classını public yaptım.
    {

        // DAL katmanı kullanılarak kitap id ye ait ogrenci verileri çekildi
        public static List<KitapOgrenciVeri> kitapOgrenciListe(KitapOgrenciVeri kitap)   //Id si verilen kitabı alan ogrencileri DAL katmanının KitapIadeDAL classının kitapOgrenciListe() fonksiyonunu kullanarak listeleyen KitapOgrenciVeri class ının nesnesini parametre alan 
                                                                                         //ve KitapOgrenciVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {
            if (kitap.KitapId != 0)                                       //kitap parametresinin KitapId değeri sıfırdan farklı ise
                return KitapIadeDAL.kitapOgrenciListe(kitap);             //KitapIadeDAL class ının kitapOgrenciListe() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapOgrenciListe() fonksiyonunun çağrıldığı yere döndürdüm.
            else                                                          //kitap parametresinin KitapId değeri sıfırdan farklı değil ise
                return null;                                              // kitapOgrenciListe fonksiyonunun çağrıldığı yere null değerini döndürdüm.
        }


        public static List<string> kitapAlinanLİste(KitapIadeVeri kitap)  //Ogrencinin aldığı kitapları DAL katmanının KitapIadeDAL classının kitapAlinanListe() fonksiyonunu kullanarak kitap adlarını listeleyen KitapIadeVeri class ının nesnesini parametre alan 
                                                                          //ve string veri türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return KitapIadeDAL.kitapAlinanListe(kitap);                  //KitapIadeDAL class ının kitapAlinanListe() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapAlinanLİste() fonksiyonunun çağrıldığı yere döndürdüm.
        }



        public static List<string> kitapTeslimLİste(KitapIadeVeri kitap)   //Öğrencinin teslim etmesi gereken kitapların ismini  DAL katmanının KitapIadeDAL classının kitapTeslimListe() fonksiyonunu kullanarak listeleyen KitapIadeVeri class ının nesnesini parametre alan 
                                                                           //ve string veri türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return KitapIadeDAL.kitapTeslimListe(kitap);                   //KitapIadeDAL class ının kitapTeslimListe() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapTeslimLİste() fonksiyonunun çağrıldığı yere döndürdüm.
        }



        public static List<string> kitapTarih(KitapIadeVeri kitap)         //Öğrencinin kitabı aldığı tarihi DAL katmanının KitapIadeDAL classının kitapTarih() fonksiyonunu kullanarak listeleyen KitapIadeVeri class ının nesnesini parametre alan 
                                                                           //ve string veri türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return KitapIadeDAL.kitapTarih(kitap);                        //KitapIadeDAL class ının kitapTarih() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapTarih() fonksiyonunun çağrıldığı yere döndürdüm.
        }

       

        public static List<string> ogrenciCeza(KitapIadeVeri kitap)       //Ogrencinin ceza bilgisini DAL katmanının KitapIadeDAL classının OgrenciCeza() fonksiyonunu kullanarak listeleyen KitapIadeVeri class ının nesnesini parametre alan 
                                                                          //ve string veri türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return KitapIadeDAL.OgrenciCeza(kitap);                       //KitapIadeDAL class ının OgrenciCeza() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciCeza() fonksiyonunun çağrıldığı yere döndürdüm.
        }


        public static int ogrenciCezaIslemi(KitapIadeVeri ogrenci)        //Öğrencinin ceza bilgisini DAL katmanının KitapIadeDAL classının ogrenciCezaIslemi() fonksiyonunu kullanarak güncelleyen KitapIadeVeri class ının nesnesini parametre alan 
                                                                          //ve integer türünde veri döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciCeza >= 0)                                 //ogrenci parametresinin OgrenciCeza değişkeni büyük eşittir 0 ise
            {

                return KitapIadeDAL.ogrenciCezaIslemi(ogrenci);           //KitapIadeDAL class ının ogrenciCezaIslemi() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciCezaIslemi() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                          //ogrenci parametresinin OgrenciCeza değişkeni büyük eşittir 0 değil ise
                return -1;                                                //ogrenciCezaIslemi() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }


        public static int grafikAlinabilir(KitapIadeVeri kitap)                   //Ögrencinin alabileceği kitapların sayısını DAL katmanının KitapIadeDAL classının grafikAlinabilir() fonksiyonunu kullanarak getiren KitapIadeVeri class ının nesnesini parametre alan 
                                                                                  //ve integer türünde veri döndüren fonksiyon yazdım.
        {
            if (kitap.OgrenciId != 0)                                             //kitap parametresinin KitapId değeri sıfırdan farklı ise
            {
                return KitapIadeDAL.grafikAlinabilir(kitap);                      //KitapIadeDAL class ının grafikAlinabilir() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri grafikAlinabilir() fonksiyonunun çağrıldığı yere döndürdüm.
            }
            return 0;                                                             //if bloğuna girmezse grafikAlinabilir() fonksiyonunun çağrıldığı yere 0 değerini döndürdüm.
        }


 
        public static int grafikVerilmis(KitapIadeVeri kitap)                     //Öğrencinin aldığı kitapların sayısını DAL katmanının KitapIadeDAL classının grafikVerilmis() fonksiyonunu kullanarak getiren KitapIadeVeri class ının nesnesini parametre alan 
                                                                                  //ve integer türünde veri döndüren fonksiyon yazdım.
        {
            if (kitap.OgrenciId != 0)                                             //kitap parametresinin OgrenciId değeri sıfırdan farklı ise
            {
                return KitapIadeDAL.grafikVerilmis(kitap);                        //KitapIadeDAL class ının grafikVerilmis() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri grafikVerilmis() fonksiyonunun çağrıldığı yere döndürdüm.
            }
            return 0;                                                             //if bloğuna girmezse grafikVerilmis() fonksiyonunun çağrıldığı yere 0 değerini döndürdüm.
        }



        public static int grafikHepsi()                                           // Tüm kitapların sayısını DAL katmanının KitapIadeDAL classının grafikHepsi() fonksiyonunu kullanarak getiren parametre almayan ve integer türünde veri döndüren fonksiyon yazdım.
        {
            return KitapIadeDAL.grafikHepsi();                                    // KitapIadeDAL class ının grafikHepsi() fonksiyonunu çağırdım ve dönen değeri kitapTarih() fonksiyonunun çağrıldığı yere döndürdüm.
        }



        public static List<AlinanKitapVeri> ogrenciIdListe(AlinanKitapVeri kitap)   //Öğrencinin almış olduğu kitapları  DAL katmanının KitapIadeDAL classının ogrenciIdListe() fonksiyonunu kullanarak tarihşeri ile getiren AlinanKitapVeri class ının nesnesini parametre alan 
                                                                                    //ve  AlinanKitapVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return KitapIadeDAL.ogrenciIdListe(kitap);                              //KitapIadeDAL class ının ogrenciIdListe() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciIdListe() fonksiyonunun çağrıldığı yere döndürdüm.
        }


        

        
        public static int kitapAlimIslemi(KitapIadeVeri kitap)                      //Ogrencinin aldığı kitabı DAL katmanının KitapIadeDAL classının kitapAlimIslemi() fonksiyonunu kullanarak KitapKayit tablosuna ekleyen KitapIadeVeri class ının nesnesini parametre alan 
                                                                                    //ve integer türünde veri döndüren fonksiyon yazdım.
        {
            if (kitap.KitapId != 0 && kitap.OgrenciId != 0 && kitap.KitapAlinma != null)  //kitap parametresinin KitapId, OgrenciId değişkenlerş sıfırdan farklı ise ve KitapAlinma değişkeni nulldan farklı ise
            {

                return KitapIadeDAL.kitapAlimIslemi(kitap);                        //KitapIadeDAL class ının kitapAlimIslemi() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapAlimIslemi() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                                   //kitap parametresinin KitapId, OgrenciId değişkenlerş sıfırdan farklı değil ise ve KitapAlinma değişkeni nulldan farklı değil ise
                return -1;                                                         //kitapAlimIslemi() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }

       

        public static int kitapTeslimIslemi(KitapIadeVeri kitap)                   //Ogrencinin teslim ettiği kitabın KitapKayit tablosundaki bilgilerini DAL katmanının KitapIadeDAL classının kitapTeslimIslemi() fonksiyonunu kullanarak güncelleyen KitapIadeVeri 
                                                                                   // class ının nesnesini parametre alan ve integer türünde veri döndüren fonksiyon yazdım.
        {
            if (kitap.KitapId != 0)                                                //kitap parametresinin KitapId değeri sıfırdan farklı ise
            {

                return KitapIadeDAL.kitapTeslimIslemi(kitap);                      //KitapIadeDAL class ının kitapTeslimIslemi() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapTeslimIslemi() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                                   //kitap parametresinin KitapId değeri sıfırdan farklı değil ise
                return -1;                                                         //kitapTeslimIslemi() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }




        public static int kitapId(KitapOgrenciVeri kitap)                // Adı girilen kitabın Id değerini DAL katmanının KitapIadeDAL classının kitapId() fonksiyonunu kullanarak getiren KitapOgrenciVeri 
                                                                         // class ının nesnesini parametre alan ve integer türünde veri döndüren fonksiyon yazdım.
        {
            if (kitap.KitapAd != "")                                     //kitap parametresinin KitapAd değeri boş değil ise 
            {

                return KitapIadeDAL.kitapId(kitap);                      //KitapIadeDAL class ının kitapId() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapId() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                         //kitap parametresinin KitapAd değeri boş ise
                return -1;                                               //kitapId() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }
    }
}

