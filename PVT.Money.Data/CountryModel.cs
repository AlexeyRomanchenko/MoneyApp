using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("Countries")]
    public class CountryEntity
    {
        [Column("CountryId"), Required]
        public int id { get; set; }
        [Column("CountryName"),Required]
        public string CountryName { get; set; }
        [Column("LocalCurrency")]
        public string LocalCurrency { get; set; }
        public ICollection<LangEntity> Languages { get; set; }

        public CountryEntity()
        {
            Languages = new List<LangEntity>();
        }
    }

}
