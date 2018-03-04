using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVT.Money.Data
{
    [Table("Languages")]
    public class LangEntity
    {
        [Key]
        public int LangId { get; set; }
        public string Lang { get; set; }
        public virtual ICollection<CountriesLangsEntity> Countries { get; set; }
        public LangEntity()
        {
            Countries = new List<CountriesLangsEntity>();
        }
    }
}