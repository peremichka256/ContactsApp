using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using NUnit.Framework;


namespace ContactsAppUnitTests
{
    [TestFixture]
    class ProjectTests
    {
        private Project _testProject;

        //TODO: у тебя здесь создается тестовый проект. В тестах менеджера тоже нужен тестовый проект - сделай так, чтобы тестовый проект использовался в обоих классах.
        public void InitProject()
        {
            _testProject = new Project();

            _testProject.Contacts.Add(new Contact(
                "3TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877666),
                new DateTime(2000, 1, 1),
                "TestEmail",
                "TestiDVK"));

            _testProject.Contacts.Add(new Contact(
                "1TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877667),
                new DateTime(2000, 2, 1),
                "TestEmail",
                "TestiDVK"));

            _testProject.Contacts.Add(new Contact(
                "2TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877668),
                new DateTime(2000, 3, 1),
                "TestEmail",
                "TestiDVK"));
        }

        [Test(Description ="Позитивный тест по передачи правильного списка")]
        public void TestProject_CorrectValue()
        {
            InitProject();

            var expectedList = _testProject.Contacts;

            Assert.AreEqual(expectedList, _testProject.Contacts, 
                "Был передан неправильный список");
        }

        [Test(Description ="Позитивный тест сортировки")]
        public void TestSortBySurname()
        {
            InitProject();
            IEnumerable<string> expected = new[]
            {
                "1testsurname",
                "2testsurname",
                "3testsurname",
            };
            List<Contact> sortedContacts = _testProject.SortBySurname();
            Assert.IsTrue(sortedContacts.Select(n => n.Surname).SequenceEqual(expected),
                "Список отсортирован неверно");
        }

        [Test(Description = "Негативный тест сортировки с подстрокой больше фамилии")]
        public void TestSortBySurname_LongerSubstringLength()
        {
            InitProject();

            List<Contact> sortedContacts = _testProject.SortBySurname("1testsurnam111");

            Assert.IsEmpty(sortedContacts, "Список осторирован по строке неверно");
        }

        [Test(Description = "Негативный тест сортировки с подстрокой отличающейся от фамилии")]
        public void TestSortBySurname_DifferentSurnameAndSubstring()
        {
            InitProject();

            List<Contact> sortedContacts = _testProject.SortBySurname("Aaa");

            Assert.IsEmpty(sortedContacts, "Список осторирован по строке неверно");
        }

        [Test(Description ="Негативный тест нахожденния именниников")]
        public void FindBirthdays_WrongMonth()
        {
            InitProject();

            List<Contact> birthdaysContacts = 
                _testProject.FindBirthdays( new DateTime(2000, 4, 1));

            Assert.IsEmpty(birthdaysContacts, "В заданный месяц менинников быть не должно");
        }

        [Test(Description = "Негативный тест нахожденния именниников")]
        public void FindBirthdays_WrongDay()
        {
            InitProject();

            List<Contact> birthdaysContacts =
                _testProject.FindBirthdays(new DateTime(2000, 1, 2));

            Assert.IsEmpty(birthdaysContacts, "В заданный день менинников быть не должно");
        }
    }
}
