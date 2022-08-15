using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;  // Access veri tabanı kütüphanesini ekledim.
using System.Data;        // Bazı sınıfları kullanmak için gerekli kütüphaneyi ekledim.

namespace DAL
{
    class Baglanti
    {

        public static OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/kutuphane.mdb");  //OleDbConnection nesnesi oluşturdum. Bağlantı adresini verdim.
        public static void Connection(OleDbCommand command)   // Komutun bağlantısının açık olup olmadığını kontrol eden parametre olarak OleDbCommand nesnesi alan bir fonksiyon oluşturdum. 
        {

            if (command.Connection.State != ConnectionState.Open)   // command ın bağlantısı bağlantı durumu açığa eşit değilse
            {
                command.Connection.Open();  // commandın bağlantısını aç.
            }
        }
    }


}
