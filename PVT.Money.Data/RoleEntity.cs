using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVT.Money.Data
{
    [Table("UserRoles")]
    public class RoleEntity
    {
        [Column("Role_Id")]
        public int ID { get; set; }
        [Column("Role")]
        public string Role { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [ForeignKey("RoleId")]
        public ICollection<PermissionsRolesEntity> Permission { get; set; }
    }
}
