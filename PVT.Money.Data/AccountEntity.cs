using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("Accounts")]
   public class AccountEntity
    {
            [Column("UserId")]
            [Key]
            public int UserId { get; set; }
            [Column("USD_Account")]
            public string USD_Account { get; set; }
            [Column("EUR_Account")]
            public string EUR_Account { get; set; }
            [Column("AUD_Account")]
            public string AUD_Account { get; set; }
    }
}
