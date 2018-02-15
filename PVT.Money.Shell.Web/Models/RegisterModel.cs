using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не должно быть пустым, от 5 до 10 символов")]
        [StringLength(10, ErrorMessage = "Oт 3 до 10 символов", MinimumLength = 3)]
        [Remote("LoginExists", "Account", HttpMethod = "POST", ErrorMessage = "Login address already registered.")]
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [BtmLineReg(ErrorMessage = "Должен быть знак _")]
        public string Password { get; set; }
        

    }
}
