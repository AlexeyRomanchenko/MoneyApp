using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("UserUSDWallets")]
    public class USD_AccountEntity
    {
        [Key]
        [Column("WalletId")]
        public int WalletId { get; set; }
        [Column("UserId")]
        public int UserId { get; set;}
        [Column("USD_Value")]
        public string UsdValue { get; set; }       
        public UserEntity User { get; set; }
    }
}
