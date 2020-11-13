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

        [Test(Description ="Негативный тест сортировки")]
        public void TestSortBySurname()
        {

        }

        [Test(Description = "Негативный тест сортировки с подстрокой")]
        public void TestSortBySurname_LongerSubstringLength()
        {

        }

        [Test(Description = "Негативный тест сортировки с подстрокой")]
        public void TestSortBySurname_DifferentSurnameAndSubxtring()
        {

        }

        [Test(Description ="Негативный тест нахожденния именниников")]
        public void FindBirthdays_WrongMonth()
        {

        }

        [Test(Description = "Негативный тест нахожденния именниников")]
        public void FindBirthdays_WrongDay()
        {

        }
    }
}
