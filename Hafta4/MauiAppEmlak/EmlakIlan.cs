using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppEmlak
{
    public class EmlakIlan
    {
        public string IlanBasligi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public int Metrekare { get; set; }

        public string Konum { get; set; }
        public int ImarOran { get; set; }

        public string IletisimTelefon { get; set; }
        public string IletisimEmail { get; set; }

        public List<string> ResimLinkleri { get; set; } = new List<string>();

    }

    public static class DataGenerator
    {
        static Random random=new Random();
        static    List<string> konumlar = ["Ankara", "İstanbul", "İzmir", "Bartın",
                "Manisa", "Antalya", "Samsun", "Rize", "Bursa", "Kayseri",
                "Aydın", "Konya", "Kütahya", "Kocaeli", "Adana", "Mersin",
                "Gaziantep", "Şanlıurfa", "Diyarbakır", "Van", "Erzurum", "Trabzon",
                "Sivas", "Malatya", "Elazığ", "Denizli", "Muğla", "Balıkesir", "Çanakkale",
            ];

        static   List<string> manzaralar = ["Deniz manzaralı", "Orman manzaralı", "Dağ havası", "Göl kenarında", "Şehir merkezinde", "Köy ortasında",
                "Kırsal alanda", "Kıyıda", 
            ];

        static  List<string> cepheler = ["Yüksek rakımda", "Düşük rakımda", "Güneşli", "Gölge", "Kuzey cepheli", "Güney cepheli", "Doğu cepheli", "Batı cepheli"];

        public static ObservableCollection<EmlakIlan> RastgeleUret(int adet)
        {
            var ilanlar = new  ObservableCollection<EmlakIlan>();
 
            for (int i = 0; i < adet; i++)
            {
                int m2 = random.Next(1000,10001);
                EmlakIlan ilan = new EmlakIlan()
                {
                    IlanBasligi = $"Satılık {m2} m2 arsa",
                    Konum = konumlar[random.Next(0,konumlar.Count)],
                    Aciklama = "Arsa satılıktır. İmar durumu vardır. " +
                                $"\n{manzaralar[random.Next(0, manzaralar.Count)]}." +
                                $"\n{cepheler[random.Next(0, cepheler.Count)]}." +
                                $"\nBu bilgiler gerçek dışıdır, random üretilmiştir.",
                    Fiyat = random.Next(1_000_000, 10_000_001),
                    ImarOran = random.Next(10, 100),
                    Metrekare = m2,

                    IletisimEmail = $"iletisimmail{i*i}@mail.com",
                    IletisimTelefon = $"+90 5{random.Next(30, 60)}-{random.Next(100, 1000)}-{random.Next(10, 100)}-{random.Next(10, 100)}",

                    ResimLinkleri = new List<string>()
                    {
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                        $"https://picsum.photos/seed/{random.Next(1000)}/500/500",
                    }
                };

                ilanlar.Add(ilan);
            }




            return ilanlar;

        }
    }
}
