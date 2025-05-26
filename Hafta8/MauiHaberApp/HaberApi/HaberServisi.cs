
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiHaberApp.HaberApi
{

        //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
   
    public static class HaberServisi
    {
        public static ObservableCollection<HaberKategori> HaberKategorileri = new ObservableCollection<HaberKategori>()
        {
            new HaberKategori("Manşet", "https://www.trthaber.com/manset_articles.rss"),
            new HaberKategori("Son Dakika", "https://www.trthaber.com/sondakika_articles.rss"),
            new HaberKategori("Koronavirüs", "https://www.trthaber.com/koronavirus_articles.rss"),
            new HaberKategori("Gündem", "https://www.trthaber.com/gundem_articles.rss"),
            new HaberKategori("Türkiye", "https://www.trthaber.com/turkiye_articles.rss"),
            new HaberKategori("Dünya", "https://www.trthaber.com/dunya_articles.rss"),
            new HaberKategori("Ekonomi", "https://www.trthaber.com/ekonomi_articles.rss"),
            new HaberKategori("Spor", "https://www.trthaber.com/spor_articles.rss"),
            new HaberKategori("Yaşam", "https://www.trthaber.com/yasam_articles.rss"),
            new HaberKategori("Sağlık", "https://www.trthaber.com/saglik_articles.rss"),
            new HaberKategori("Kültür & Sanat", "https://www.trthaber.com/kultur_sanat_articles.rss"),
            new HaberKategori("Bilim & Teknoloji", "https://www.trthaber.com/bilim_teknoloji_articles.rss"),
            new HaberKategori("Güncel", "https://www.trthaber.com/guncel_articles.rss"),
            new HaberKategori("Eğitim", "https://www.trthaber.com/egitim_articles.rss"),
            new HaberKategori("İnfografik", "https://www.trthaber.com/infografik_articles.rss"),
            new HaberKategori("İnteraktif", "https://www.trthaber.com/interaktif_articles.rss"),
            new HaberKategori("Özel Haber", "https://www.trthaber.com/ozel_haber_articles.rss"),
            new HaberKategori("Dosya Haber", "https://www.trthaber.com/dosya_haber_articles.rss"),

        };

        public static async Task< List<HaberApi.Item>> GetHaberler(HaberKategori kategori)
        {
            var link = $"https://api.rss2json.com/v1/api.json?rss_url={kategori.KategoriUrl}";
            var jsonData = await GetJSonData(link);

            var root = JsonSerializer.Deserialize<HaberApi.Root>(jsonData);
            return root.items;
        }

        public static async Task<string> GetJSonData(string url )
        {
            string jsonData = "";
            HttpClient client = new HttpClient();
            var message = await client.GetAsync(url);

            message.EnsureSuccessStatusCode();
            jsonData = await message.Content.ReadAsStringAsync();

            return jsonData;
        }

    }

}
