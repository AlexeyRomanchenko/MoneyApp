using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVT.Money.Data
{
    [Table("Users")]
    public class UserEntity
    {
        [Column("Id")]
        [Required]
        public int ID { get; set; }
        [Column("Username")]
        [Required]
        public string Username { get; set; }
        [Column("Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        [Required]
        public string Password { get; set; }
        [Column("Role_Id")]
        public int Role_Id { get; set; }
        [ForeignKey("Role_Id")]
        public RoleEntity Role { get; set; }
    }

  
}
