using System;
using NUnit.Framework;
using ContactsApp;

namespace CAUT
{
    [TestFixture]
    public class ContactTest
    {
        private Contact _contact;

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }

        [Test(Description = "Позитивный геттер-тест Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            var expected = "Иванов";
            _contact.Surname = expected;
            var actual = _contact.Surname;
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [TestCase("", "Должно возникать исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Иванов-Иванов-Иваов-Иванов-Иванов-Иванов-Иванов-Иванов-Иванов-Иванов",
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии больше 50 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "Позитивный геттер-тест Name")]
        public void TestNameGet_CorrectValue()
        {
            var expected = "Иван";
            _contact.Name = expected;
            var actual = _contact.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }

        [TestCase("", "Должно возникать исключение, если имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван",
            "Должно возникать исключение, если имя длиннее 50 символов",
            TestName = "Присвоение неправильного имени больше 50 символов")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = wrongName; },
                message);
        }

        [Test(Description = "Позитивный геттер-тест Number")]
        public void TestNumberGet_CorrectValue()
        {
            _contact.Number = new PhoneNumber();
            _contact.Number.Number = "77777777777";
            var expected = _contact.Number;
            _contact.Number = expected;
            var actual = _contact.Number;
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильный номер");
        }

        [Test(Description = "Позитивный геттер-тест Birthday")]
        public void TestBirthdayGet_CorrectValue()
        {
            var expected = new DateTime(1999, 04, 02);
            _contact.Birthday = expected;
            var actual = _contact.Birthday;
            Assert.AreEqual(expected, actual, "Геттер Birthday возвращает неправильное значение");
        }

        [TestCase("01/01/1899", "Должно возникать исключение, если дата раньше 01/01/1900",
            TestName = "Присвоение неправильной даты, которая раньше 01/01/1900")]
        [TestCase("05/01/2200",
            "Должно возникать исключение, если дата позже сегодняшняшней",
            TestName = "Присвоение неправильной даты, которая позже сегодняшней")]
        public void TestBirthdaySet_ArgumentException(string date, string message)
        {
            var wrongDate = DateTime.Parse(date);
            Assert.Throws<ArgumentException>(
                () => { _contact.Birthday = wrongDate; },
                message);
        }

        [Test(Description = "Позитивный геттер-тест Email")]
        public void TestEmailGet_CorrectValue()
        {
            var expected = "hello@mail.ru";
            _contact.Email = expected;
            var actual = _contact.Email;
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильное значение");
        }

        [Test(Description = "Позитивный геттер-тест IdVk")]
        public void TestIDVKGet_CorrectValue()
        {
            var expected = "1112332122";
            _contact.IdVk = expected;
            var actual = _contact.IdVk;
            Assert.AreEqual(expected, actual, "Геттер IDVK возвращает неправильное значение");
        }

        [TestCase("12345678910111213", "Должно возникать исключение, если IdVk больше 15 символов",
            TestName = "Присвоение неправильного IdVk, больше 15 символов")]
        public void TestIDVKSet_ArgumentException(string iDVK, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.IdVk = iDVK; },
                message);
        }
    }
}
    

