using System;
using System.Collections.Generic;
using System.Text;

namespace PVT.Money.Business
{
    class Registration
    {
        string name;
        string email;
        string login;
        string password1;
        string password2;      

        public Registration()
        {
            // Конструктор
        }

        public bool IsLoginCorrect()
        {
            // Логика метода
            return true;
        }

        public bool IsPasswordCorrect()
        {
            // Логика метода
            return true;
        }

        public bool IsPasswordCoinside()
        {
            // Логика метода
            return true;
        }
        
        public User UserCreate()
        {
            // Логика метода
            return User;
        }

    }
}
