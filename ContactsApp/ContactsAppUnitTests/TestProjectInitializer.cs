using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;


namespace ContactsAppUnitTests
{
    /// <summary>
    /// Сервисный класс для создания тестового проекта
    /// </summary>
    static public class TestProjectInitializer
    {
        /// <summary>
        /// Инициализация тестового проекта
        /// </summary>
        /// <returns>Созданный проект для тестов</returns>
        static public Project InitProject()
        {
            var testProject = new Project();

            testProject.Contacts.Add(new Contact(
                "3TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877666),
                new DateTime(2000, 1, 1),
                "TestEmail",
                "TestiDVK"));

            testProject.Contacts.Add(new Contact(
                "1TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877667),
                new DateTime(2000, 2, 1),
                "TestEmail",
                "TestiDVK"));

            testProject.Contacts.Add(new Contact(
                "2TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877668),
                new DateTime(2000, 3, 1),
                "TestEmail",
                "TestiDVK"));

            return testProject;
        }
    }
}
