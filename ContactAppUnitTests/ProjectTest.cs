using System;
using System.Collections.Generic;
using ContactsApp;
using NUnit.Framework;

namespace CAUT
{
    [TestFixture]
    class ProjectTest
    {
        private Project _project;
        private Contact _contact;

        public void InitProject()
        {
            _project = new Project();
            _project.Contacts = new List<Contact>();
            _contact = new Contact();
        }

        [TestCase(TestName = "Добавление нового контакта в список")]
        public void TestProject()
        {
            InitProject();
            _contact.Number = new PhoneNumber();
            _contact.Number.Number = "77777777777";
            _contact.Name = "Name";
            _contact.Surname = "Surname";
            _contact.IdVk = "12345";
            _contact.Email = "hello@mail.ru";
            _project.Contacts.Add(_contact);
            Assert.AreEqual(_project.Contacts[0].Name, "Name");
            Assert.AreEqual(_project.Contacts[0].Surname, "Surname");
            Assert.AreEqual(_project.Contacts[0].IdVk, "12345");
            Assert.AreEqual(_project.Contacts[0].Email, "hello@mail.ru");
            Assert.AreEqual(_project.Contacts[0].Number.Number, "77777777777");
        }
    }
}
    