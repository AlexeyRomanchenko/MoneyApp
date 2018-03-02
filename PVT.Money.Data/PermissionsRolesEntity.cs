using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("PermissionsRoles")]
    public class PermissionsRolesEntity
    {
        
        [Column("Role_Id")]
        [Required]
        public int RoleId { get; set; }
        
        [Column("Rule_Id")]
        [Required]
        public int RuleId { get; set; }

        [ForeignKey("RoleId")]
        public RoleEntity UserRoles { get; set; }
        [ForeignKey("RuleId")]
        public PermissionEntity Permissions { get; set; }
    }
}
