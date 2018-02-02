using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Не должно быть пустым, от 5 до 10 символов")]
        [StringLength(10,ErrorMessage = "Oт 5 до 10 символов", MinimumLength = 5)]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
