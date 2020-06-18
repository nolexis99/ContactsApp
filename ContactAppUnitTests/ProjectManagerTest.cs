using System;
using ContactsApp;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAUT
{
    [TestFixture]
    class ProjectManagerTest
    {
        private ProjectManager _projectManager;
        private Project _project;
        private readonly string testPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ContactAppTest.json";
        private readonly string originContactAppTestDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\OriginContactAppTestData.json";

        public void InitProjectManager()
        {
                _project = new Project();
                _projectManager = new ProjectManager();
                _project.Contacts = new List<Contact>();
                var _contact = new Contact();
                _contact.Number = new PhoneNumber();
                _contact.Surname = "Surname";
                _contact.Name = "Name";
                _contact.Number.Number = "77777777777";
                _contact.Birthday = DateTime.Parse("01/01/2001");
                _contact.Email = "hello@mail.ru";
                _contact.IdVk = "12345";
                _project.Contacts.Add(_contact);
        }

        [TestCase(TestName = "Тест сериализации проекта")]
        public void SaveToFileTest()
        {
            InitProjectManager();
            var expected = File.ReadAllText(originContactAppTestDataPath);
            _projectManager.SaveToFile(_project, testPath);
            var actual = File.ReadAllText(testPath);

            Assert.AreEqual(expected, actual, "Метод SaveToFile неверно сохраняет данные");
        }

        [TestCase("Name", "Surname", "hello@mail.ru",
            TestName = "Тест дессериализации проекта")]
        public void LoadFromFileTest(string expectedName, string expectedSurname, string expectedEmail)
        {
            InitProjectManager();
            _projectManager.SaveToFile(_project, testPath);
            var actual = _projectManager.LoadFromFile(testPath);
            Assert.AreEqual(expectedName, actual.Contacts[0].Name);
            Assert.AreEqual(expectedSurname, actual.Contacts[0].Surname);
            Assert.AreEqual(expectedEmail, actual.Contacts[0].Email);
        }

        [TearDown]
        public void RemoveFile()
            {
                if (File.Exists(testPath))
                {
                    File.Delete(testPath);
                }
            }

    }
}

