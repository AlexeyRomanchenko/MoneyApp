namespace PVT.Money.Data
{
    public class CountriesLangsEntity
    {
        public int CountryId { get; set; }
        public CountryEntity Countries { get; set; } 
        public int LangId { get; set; }
        public LangEntity Langs { get; set; }

    }
}