using System;
using System.Globalization;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакт.
    /// </summary>
    public class Contact 
    {
        /// <summary>
        /// Фамилия контакта.
        /// </summary>
        private string _surname; 
       
        /// <summary>
        /// Имя контакта.
        /// </summary>
        private string _name;

        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        private DateTime _birthday;
        
        /// <summary>
        /// Email контакта.
        /// </summary>
        private string _email;
       
        /// <summary>
        /// IdVK контакта.
        /// </summary>
        private string _idVk;
       
        private TextInfo FirstUppercaseLetter = CultureInfo.CurrentCulture.TextInfo;

        /// <summary>
        /// Метод, который возвращает и задает значение фамилии контакта.
        /// </summary>
        public string Surname
        {
            get { return _surname; }

            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Фамилия должна быть длиннее 0 символов");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Фамилия не должна быть длиннее 50 символов");
                }
                else 
                     _surname = value;
                _surname = FirstUppercaseLetter.ToTitleCase(_surname);
            }
        }

        /// <summary>
        /// Метод, который возвращает и задает значение имени контакта.
        /// </summary>
        public string Name
        {
            get { return _name; }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Имя должно быть длиннее 50 символов");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Имя не должно быть длиннее 50 символов");
                }
                else
                    _name = value;
                _name = FirstUppercaseLetter.ToTitleCase(_name);
            }
        }

        /// <summary>
        /// Метод, который возвращает и задает значение номера телефона контакта.
        /// </summary>
        public PhoneNumber Number { get; set; }

        /// <summary>
        /// Метод, который возвращает и задает значение даты рождения контакта.
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
               
                if (value > DateTime.Today)
                    throw new ArgumentException("Дата рождения не может быть больше сегодняшней");
                DateTime dateTime = new DateTime(1900, 01, 01);
                if (value <  dateTime)
                    throw new ArgumentException("Дата рождения не может быть меньше 1900.01.01");
                else
                    _birthday = value;
            }
        }

        /// <summary>
        /// Метод, который возвращает и задает значение Email'a контакта.
        /// </summary>
        public string Email
        {
            get { return _email;}
            set { _email = value;}
        }

        /// <summary>
        /// Метод, который возвращает и задает значение IdVk контакта.
        /// </summary>
        public string IdVk
        {
            get { return _idVk; }
            set
            {
                if (value.Length > 15)
                    throw new ArgumentException("IdVk не должен превышать 15 символов");
                else
                    _idVk = value;
            }
        }
    }
}