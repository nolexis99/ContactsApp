using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс номера телефона.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона контакта.
        /// </summary>
        private string _number;

        /// <summary>
        /// Метод, который возвращает и задает значение номера телефона контакта.
        /// </summary>
        public string Number
        {
            get { return _number; }
            set
            {
                
                if (value.Length != 11)
                    throw new ArgumentException("Дина номера должна быть равна 11");
                if (value.StartsWith("7") == false)
                    throw new ArgumentException("Номер должен начинаться с 7");
                else
                    _number = value;
            }
        }
    }
}