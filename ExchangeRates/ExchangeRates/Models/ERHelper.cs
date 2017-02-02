using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Net.Http;

namespace ExchangeRates.Models
{
    public static class ERHelper
    {
        private static List<ValCurs> _rates = new List<ValCurs>();

        private async static Task<ValCurs> LoadRateAsync(DateTime day)
        {
            using (var client = new HttpClient())
            {
                
                var url = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + day.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                var page = await (await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url))).Content.ReadAsStringAsync();
                var serializer = new XmlSerializer(typeof(ValCurs));

                using (var stream = new MemoryStream(Encoding.GetEncoding("windows-1251").GetBytes(page ?? "")))
                {
                    return (ValCurs)serializer.Deserialize(stream);
                }
            }
        }

        public async static Task<ValCurs> GetRateAsync(DateTime day)
        {
            var rate = _rates.Find(v => v.Date == day);

            if (rate == null)
            {
                rate = await LoadRateAsync(day);
                _rates.Add(rate);
            }

            return rate;
        }

        public async static Task<Currency[]> GetCurrenciesAsync(DateTime day, params string[] currency)
        {
            return (await GetRateAsync(day))
                .Valutes
                .Where(v => currency.Contains(v.CharCode))
                .Select(v => new Currency(v.CharCode, v.Value))
                .ToArray();
        }
    }
}
