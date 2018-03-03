using System.Collections.Generic;

namespace PVT.Money.Data
{
    public class LangEntity
    {
        public int ID { get; set; }
        public string Lang { get; set; }
        public virtual ICollection<CountryEntity> Countries { get; set; }
        public LangEntity()
        {
            Countries = new List<CountryEntity>();
        }
    }
}