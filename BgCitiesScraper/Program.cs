namespace BgCitiesScraper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AngleSharp.Dom;
    using AngleSharp.Html.Parser;
    using Newtonsoft.Json;

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string url = "https://bg.wikipedia.org/wiki/%D0%93%D1%80%D0%B0%D0%B4%D0%BE%D0%B2%D0%B5_%D0%B2_%D0%91%D1%8A%D0%BB%D0%B3%D0%B0%D1%80%D0%B8%D1%8F";
            var parser = new HtmlParser();
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();
            var document = parser.ParseDocument(html);

            var rows = document.QuerySelectorAll("table.wikitable tbody tr").ToList();
            var cities = new List<City>();

            foreach(var row in rows.Skip(1))
            {
                var city = CreateCity(row);
                cities.Add(city);
            }

            Console.WriteLine(cities.Count);
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Name} ({city.NameInLatin}) - {city.Municipality} ({city.MunicipalityInLatin})");
            }

            
            using (StreamWriter file = new StreamWriter("../../../cities.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, cities);
            }

        }


        private static City CreateCity(IElement tableRow)
        {
            string cityName = tableRow.QuerySelector("td:first-child a[title]").InnerHtml;
            string municipality = tableRow.QuerySelector("td:nth-child(2) a[title]").InnerHtml;
            string cityInLatin = CyrillicToLatinConverter.Convert(cityName);
            string municipalityInLatin = CyrillicToLatinConverter.Convert(municipality);
            return new City(cityName, cityInLatin, municipality, municipalityInLatin);
        }
        
    }
}
