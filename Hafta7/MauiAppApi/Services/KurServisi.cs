using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppApi.Services
{
    public static class KurServisi
    {
        public static async Task<string> GetKurJSonData(string url= "https://hasanadiguzel.com.tr/api/kurgetir")
        {
            string jsonData = "";
            HttpClient client = new HttpClient();
            var message = await client.GetAsync(url);

            message.EnsureSuccessStatusCode();
            jsonData = await message.Content.ReadAsStringAsync();

            return jsonData;
        }


        public static async Task<List<TCMBAnlikKurBilgileri>> GetKurBilgileri()
        {
            var json = await GetKurJSonData();
            var root = JsonSerializer.Deserialize<Root>(json);


            return root.TCMB_AnlikKurBilgileri;
        }


    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Developer
    {
        public string name { get; set; }
        public string website { get; set; }
        public string email { get; set; }
    }

    public class Root
    {
        public Developer Developer { get; set; }
        public List<TCMBAnlikKurBilgileri> TCMB_AnlikKurBilgileri { get; set; }
    }

    public class TCMBAnlikKurBilgileri
    {
        public string Isim { get; set; }
        public string CurrencyName { get; set; }
        public double ForexBuying { get; set; }
        public object ForexSelling { get; set; }
        public object BanknoteBuying { get; set; }
        public object BanknoteSelling { get; set; }
        public object CrossRateUSD { get; set; }
        public object CrossRateOther { get; set; }
    }




}
