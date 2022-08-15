using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;      // DAL katmanını kullanmak için ekledim.
using Entity;   // Entity katmanını kullanmak için ekledim.

namespace BL
{
    public class GorevliBL  //Diğer classlardan erişebilmek için GorevliBl classını public yaptım.
    {        

        //Girilen bilgilere ait görevli veri tabanında kayıtlı mı diye kontrol edildi DAL katmanı kullanılarak yaptık
        
        public static bool gorevliKontrol_BL(GorevliVeri gorevli)   //Girilen Tc ve şifreye ait görevli veritabanında kayıtlımı kontrolünü DAL katmanının GorevliDAL class ının gorevliKontrol() fonksiyonu ile yapan GorevliVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            if (gorevli.gorevTc != "" && gorevli.gorevSifre != "")  //gorevli parametresinin gorevliTc alanı ve gorevliSifre alanı dolu ise
                return GorevliDAL.gorevliKontrol(gorevli);          //GorevliDal class ının gorevliKontrol() fonksiyonuna gorevli paremetresini gönderdim ve fonksiyondan dönen değeri gorevliKontrol_BL() fonksiyonunun çağrıldığı yere döndürdüm.

            else                                                    // gorevli parametresinin gorevliTc alanı ve/veya gorevliSifre alanı dolu değil ise
                return false;                                       // gorevliKontrol_BL fonksiyonunun çağrıldığı yere false değerini döndürdüm.
        }
    }
}