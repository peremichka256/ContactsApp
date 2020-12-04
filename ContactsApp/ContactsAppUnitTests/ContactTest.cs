using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using NUnit.Framework;
//TODO: Проект должен быть в подпапке Testing, название проекта должно отделять UnitTests через точку от имени тестируемой сборки

namespace ContactsAppUnitTests
{
    //TODO: неправильное именование класса
    //Извините за то, что не умею читать
    //TODO: в множественном числе. Test - это для названия методов, Tests - для названия классов, так как каждый класс содержит много тестов
    [TestFixture]
    public class ContactTests
    {
        public Contact InitTestContact()
        {
            Contact testContact = new Contact(
                "TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877666),
                new DateTime(2000, 1, 1),
                "TestEmail",
                "TestiDVK");
            return testContact;
        }

        [Test(Description = "Негативный тест сеттера Surname")]
        public void TestSurnameSet_UncorrectValue()
        {
            var testContact = InitTestContact();

            Assert.Throws<Exception>(()=> 
            { testContact.Surname = "WrongSurnameWrongSurnameWrongSurnameWrongSurnameWro"; },
            "Возникает, если длина больше 50 символов");
        }

        [Test(Description = "Негативный тест сеттера FirstName")]
        public void TestFirstnameSet_UncorrectValue()
        {
            var testContact = InitTestContact();

            Assert.Throws<Exception>(() =>
            { testContact.Firstname = "WrongFirstnameWrongFirstnameWrongFirstnameWrongFirs"; },
            "Возникает, если длина больше 50 символов");
        }

        [Test(Description = "Негативный тест сеттера Birthdate при дате меньше минимальной")]
        public void TestBirthDateSet_MoreCurrentDate()
        {
            var testContact = InitTestContact();

            Assert.Throws<Exception>(() =>
            { testContact.BirthDate = new DateTime(1899,12,31); },
            "Возникает, если дата меньше минимально доступной");
        }

        [Test(Description = "Негативный тест сеттера Birthdate при дате больше текущей")]
        public void TestBirthDateSet_LessMinDate()
        {
            var testContact = InitTestContact();

            Assert.Throws<Exception>(() =>
            { testContact.BirthDate = DateTime.MaxValue; },
            "Возникает, если дата больше максимально доступной");
        }

        [Test(Description = "Негативный тест сеттера Email")]
        public void TestEmailSet_UncorrectValue()
        {
            var testContact = InitTestContact();

            Assert.Throws<Exception>(() =>
            { testContact.Email = "WrongEmailWrongEmailWrongEmailWrongEmailWrongEmail1"; },
            "Возникает, если длина больше 50 символов");
        }

        [Test(Description = "Негативный тест сеттера IDVK")]
        public void TestIDVKSet_UncorrectValue()
        {
            var testContact = InitTestContact();

            Assert.Throws<Exception>(() =>
            { testContact.IDVK = "WrongIdWrongId12"; },
            "Возникает, если длина больше 15 символов");
        }

        [Test(Description = "Позитивный тест конструктора Contact")]
        public void TestContactConstructor_CorrectValues()
        {
            var actualContact = InitTestContact();
            var expectedContact = new Contact(
                actualContact.Surname,
                actualContact.Firstname,
                actualContact.PhoneNumber,
                actualContact.BirthDate,
                actualContact.Email,
                actualContact.IDVK
                );

            Assert.IsTrue(actualContact.Equals(expectedContact), "Контакт создан неправильно");

        }

        //TODO: именование
        [Test(Description = "Позитивный тест метода копирования")]
        public void TestContactClone_CorrectValue()
        {
            var testContact = InitTestContact();

            Contact cloneContact = (Contact)testContact.Clone();
            //TODO: дублирование кода по проверке контактов.
            //TODO: А вообще правильнее делать реализацию метода Equals в классе Contact, чтобы в тестах просто использовать AreEquals(expectedContact, actualContact) вместо сравнения по отдельным полям
            Assert.IsTrue(testContact.Equals(cloneContact), "Контакт скопирован некорректно");
        }
    }
}
