namespace BgCitiesScraper
{
    using System.Collections.Generic;
    public class CyrillicToLatinConverter
    {
        public CyrillicToLatinConverter()
        {

        }

        public static string Convert(string word)
        {
            var transliterationTable = new Dictionary<string, string>()
            {
                ["а"] = "a",
                ["б"] = "b",
                ["в"] = "v",
                ["г"] = "g",
                ["д"] = "d",
                ["е"] = "e",
                ["ж"] = "zh",
                ["з"] = "z",
                ["и"] = "i",
                ["й"] = "i",
                ["к"] = "k",
                ["k"] = "k",
                ["л"] = "l",
                ["м"] = "m",
                ["н"] = "n",
                ["о"] = "o",
                ["п"] = "p",
                ["р"] = "r",
                ["с"] = "s",
                ["т"] = "t",
                ["у"] = "u",
                ["ф"] = "f",
                ["х"] = "h",
                ["ц"] = "ts",
                ["ч"] = "ch",
                ["ш"] = "sh",
                ["щ"] = "sht",
                ["ъ"] = "y",
                ["ь"] = "i",
                ["ю"] = "yu",
                ["я"] = "ya",
                ["А"] = "A",
                ["Б"] = "B",
                ["В"] = "V",
                ["Г"] = "G",
                ["Д"] = "D",
                ["Е"] = "E",
                ["Ж"] = "Zh",
                ["З"] = "Z",
                ["И"] = "I",
                ["Й"] = "I",
                ["К"] = "K",
                ["Л"] = "L",
                ["М"] = "M",
                ["Н"] = "N",
                ["О"] = "O",
                ["П"] = "P",
                ["Р"] = "R",
                ["С"] = "S",
                ["Т"] = "T",
                ["У"] = "U",
                ["Ф"] = "F",
                ["Х"] = "H",
                ["Ц"] = "Ts",
                ["Ч"] = "Ch",
                ["Ш"] = "Sh",
                ["Щ"] = "Sht",
                ["Ъ"] = "Y",
                ["Ь"] = "I",
                ["Ю"] = "Yu",
                ["Я"] = "Ya",
            };

            for (int i = 0; i < word.Length; i++)
            {
                var currentLeter = word[i].ToString();
                if (transliterationTable.ContainsKey(currentLeter))
                {
                    word = word.Replace(currentLeter, transliterationTable[currentLeter]);
                }

            }

            return word;
        }
    }
}
