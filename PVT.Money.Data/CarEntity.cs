using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("Cars")]
    public class CarEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Car_name")]
        public string Car_name { get; set; }
        [Column("Engine_Id")]
        public int Engine_Id { get; set; }
        [ForeignKey("Engine_Id")]
        public EngineEntity Engine { get; set; }
    }
}
