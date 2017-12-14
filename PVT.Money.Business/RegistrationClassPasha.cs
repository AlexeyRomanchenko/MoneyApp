using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business.Models;
using PVT.Money.Business.Enums;

namespace PVT.Money.Business
{
    class RegistrationClassPasha
    { 
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

        public void CreateNewUser(string name, string login, string password, UserRoles role)
        {
            UserModel newUser = new UserModel();
            newUser.Name = name;
            newUser.Login = login;
            newUser.Password = password;
            newUser.Role = role;
        }
    }
}
