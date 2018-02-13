using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVT.Money.Data
{
    [Table("Engines")]
    public class EngineEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Engine_type")]
        public string Engine_type { get; set;}
        [Column("Turbo")]
        public bool Turbo { get; set;}
        [Column("Volume_engine")]
        public string Volume_engine { get; set; }
        [Column("Moment")]
        public string Moment { get; set; }
        [Column("Capacity")]
        public string Capacity { get; set; }
    }
}
