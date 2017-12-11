using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business.Models;
using PVT.Money.Business.Enums;

namespace PVT.Money.Business
{
    public class Registration
    {
        string name;
        string login;
        string password;    

        public Registration(string name, string login, string password)
        {
            this.login = login;
            this.name = name;
            this.password = password;
        }

        private bool IsLoginCorrect()
        {
            // проверка на существования пользователя с таким же именем
            // проверка на корректность введенных данных
            return true;
        }

        private bool IsPasswordCorrect()
        {
            // проверка на корректность введенного пароля
            return true;
        }
        
        public UserModel UserCreate()
        {
            UserModel newUser = new UserModel();
            newUser.Login = this.login;
            newUser.Name = this.name;
            newUser.Password = this.password;
            newUser.Role = UserRoles.Guest;
            return newUser;
        }
    }
}
