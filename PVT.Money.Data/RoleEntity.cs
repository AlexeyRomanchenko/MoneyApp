using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PVT.Money.Data
{
    [Table("UserRoles")]
    public class RoleEntity
    {
        [Column("Role_Id")]
        [Required]
        public int ID { get; set; }
        [Column("Role")]
        [Required]
        public string Role { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [ForeignKey("RoleId")]
        public virtual ICollection<PermissionsRolesEntity> Permission { get; set; }

    }
}
