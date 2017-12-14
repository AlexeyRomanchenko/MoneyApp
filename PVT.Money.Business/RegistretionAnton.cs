using System;
using System.Collections.Generic;
using System.Text;
using PVT.Money.Business.Models;
using PVT.Money.Business.Enums;


namespace PVT.Money.Business
{
    public class RegistretionAnton
    {         
        public bool IsLoginCorrect(string login)
        {
            // проверка на существования пользователя с таким же именем
            // проверка на корректность введенных данных
            return true;
        }

        public bool IsPasswordCorrect(string password)
        {
            // проверка на корректность введенного пароля
            return true;
        }

        public bool IsPasswordsMatch(string password, string passwordConfirm)
        {
            if (password == passwordConfirm)
            {
                return true;
            }
            return false;
        }

        private void SaveUser(UserModel newUser)
        {
            // сохраняем пользовотеля
        }

        public bool IsUserCreate(string name, string login, string password, string passwordConfirm, UserRoles roles)
        {
            if (IsLoginCorrect(login) &&IsPasswordCorrect(password) && IsPasswordsMatch(password,passwordConfirm))
            {
                UserModel newUser = new UserModel
                {
                    Login = login,
                    Name = name,
                    Password = password,
                    Role = roles
                };
                SaveUser(newUser);
                return true;
            }
            return false;
        }        
    }
}
