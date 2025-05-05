using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppApi.Services
{
    public static class HavaDurumuServisi
    {
        

        /*
         Merkez (m=ANKARA)
        Anlık durum gösterimi ve tahminler için kullanılması zorunludur. Merkez isimleri büyük harflerle ve Türkçe karakter kullanılmadan yazılmalıdır. Afyonkarahisar için AFYON değil AFYONKARAHISAR kullanılmalıdır. Kahramamaraş içinse K.MARAS kullanılmaktadır.

        Merkez olarak tüm illerimizin yanında http://www.mgm.gov.tr/tahmin/il-ve-ilceler.aspx adresinde illerin altında listelenen ilçeler de kullanılabilir.

        Merkez isimlerinde ç, Ç, ö, Ö, ş, Ş, ı, İ, ü, Ü, ğ, Ğ'den olaşan Türkçe harfler yerine c, C, o, O, s, S, i, I, u, U, g, G karakterlerini kullanmalısınız.

        Gün (basla=1, bitir=5) (Sadece Tahmin İçin)
        Tahminler için kullanılması zorunludur. 5 günlük tahmin süreci içinde istenilen günden başlanılır ve istenilen gün ile bitirilir.
         */

        public static async Task<string> GetHavaDurumuUrlByCity(string city)
        {
            string url = "";
            city = city.ToUpper();
            city = city.Replace("Ç", "C");
            city = city.Replace("Ğ", "G");
            city = city.Replace("İ", "I");
            city = city.Replace("Ö", "O");
            city = city.Replace("Ş", "S");
            city = city.Replace("Ü", "U");

            if (city == "KAHRAMANMARAS")
                city = "K.MARAS";
            else if (city == "AFYON")
                city = "AFYONKARAHISAR";

            url = $"https://www.mgm.gov.tr/sunum/tahmin-show-2.aspx?m={city}&basla=1&bitir=5&rC=BBB&rZ=fff";

            return url;
        }





    }

    public class SehirHavaDurumu
    {
        public SehirHavaDurumu(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string Url => HavaDurumuServisi.GetHavaDurumuUrlByCity(Name).Result;
    }
}
