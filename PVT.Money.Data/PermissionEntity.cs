using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("Permissions")]
    public class PermissionEntity
    {
        [Key]
        [Column("Rule_Id")]
        public int RuleId { get; set; }
        [Column("Rules")]
        public string Rule { get; set; }
        [ForeignKey("RuleId")]
        public ICollection<PermissionsRolesEntity> Role { get; set; }
    }
}
