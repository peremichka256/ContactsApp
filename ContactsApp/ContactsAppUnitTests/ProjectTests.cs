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
    public class ProjectTests
    {
        //TODO: у тебя здесь создается тестовый проект. В тестах менеджера тоже нужен тестовый проект - сделай так, чтобы тестовый проект использовался в обоих классах.
        [Test(Description ="Позитивный тест по передачи правильного списка")]
        public void TestProject_CorrectValue()
        {
            var testProject = TestProjectInitializer.InitProject();

            var expectedList = testProject.Contacts;

            Assert.AreEqual(expectedList, testProject.Contacts, 
                "Был передан неправильный список");
        }

        [Test(Description ="Позитивный тест сортировки")]
        public void TestSortBySurname()
        {
            var testProject = TestProjectInitializer.InitProject();

            IEnumerable<string> expected = new[]
            {
                "1testsurname",
                "2testsurname",
                "3testsurname",
            };
            List<Contact> sortedContacts = testProject.SortBySurname();

            Assert.IsTrue(sortedContacts.Select(n => n.Surname).SequenceEqual(expected),
                "Список отсортирован неверно");
        }

        [TestCase("1testsurnam111", Description = "Тест сортировки с подстрокой больше фамилии")]
        [TestCase("Aaa", Description = "Тест сортировки с подстрокой отличающейся от фамилии")]
        [Test(Description = "Негативный тест сортировки")]
        public void TestSortBySurname_WrongSubstring(string wrongSubstring)
        {
            var testProject = TestProjectInitializer.InitProject();

            List<Contact> sortedContacts = testProject.SortBySurname(wrongSubstring);

            Assert.IsEmpty(sortedContacts, "Список осторирован по строке неверно");
        }

        [TestCase(2000, 4, 1, Description = "В заданный месяц менинников быть не должно")]
        [TestCase(2000, 1, 2, Description = "В заданный день менинников быть не должно")]
        [Test(Description ="Негативный тест нахожденния именниников")]
        public void FindBirthdays_WrongDate(int year, int month, int day)
        {
            var wrongDate = new DateTime(year, month, day);
            var testProject = TestProjectInitializer.InitProject();

            List<Contact> birthdaysContacts = 
                testProject.FindBirthdays(wrongDate);

            Assert.IsEmpty(birthdaysContacts, "В заданную дату менинников быть не должно");
        }
    }
}
