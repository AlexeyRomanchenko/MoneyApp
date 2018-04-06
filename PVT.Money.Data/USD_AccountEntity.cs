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
        [Required]
        public int WalletId { get; set; }
        [Column("UserId")]
        [Required]
        public string UserId { get; set;}
        [Column("WalletName")]
        public string WalletName { get; set; }
        [Column("Currency")]
        public string Currency { get; set; }
        [Column("USD_Value")]
        public decimal Value { get; set; }       
        public ApplicationUser User { get; set; }
    }
}
