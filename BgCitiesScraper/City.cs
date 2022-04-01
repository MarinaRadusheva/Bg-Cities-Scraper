namespace BgCitiesScraper
{
    public class City
    {

        private string name;

        private string nameInLatin;
        
        private string municipality;
        
        private string municipalityInLatin;
        public City(string name, string nameInLatin, string municipality, string municipalityInLatin)
        {
            this.name = name;
            this.nameInLatin = nameInLatin;
            this.municipality = municipality;
            this.municipalityInLatin = municipalityInLatin;
        }

        public string Name => this.name;
        public string NameInLatin => this.nameInLatin;
        public string Municipality => this.municipality;
        public string MunicipalityInLatin => this.municipalityInLatin;
    }
}
