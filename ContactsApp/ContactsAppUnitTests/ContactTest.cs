using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using NUnit.Framework;


namespace ContactsAppUnitTests
{
    //TODO: неправильное именование класса
    //А как? Просто в методичке пример так же называется, я думал правильно.
    [TestFixture]
    public class ContactTest
    {
        //TODO: не надо работать через поле - тогда тесты могут быть зависимы друг от друга. Сделай просто возвращаемое значение
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

        //TODO: а где тесты конструктора с неправильными значениями?
        [Test(Description = "Позитивный тест конструктор Contact")]
        public void TestContactConstructor_CorrectValues()
        {
            var testContact = InitTestContact();

            var expectedSurname = "Testsurname1";
            testContact.Surname = expectedSurname;
            var expectedFirstname = "Testfirstname1";
            testContact.Firstname = expectedFirstname;
            var expectedBirthDate = new DateTime(2000,1,1);
            testContact.BirthDate = expectedBirthDate;
            var expectedPhoneNumber = new PhoneNumber(79998877667);
            testContact.PhoneNumber = expectedPhoneNumber;
            var expectedEmail = "Testemail";
            testContact.Email = expectedEmail;
            var expectedIDVK = "TestiDVK";
            testContact.IDVK = expectedIDVK;

            var actualSurname = testContact.Surname;
            //TODO: если в тесте больше одного Assert, тогда их надо объединять через Assert.Multiple()
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname,
                "Неверное присвоение фамилии");
                var actualFirstName = testContact.Firstname;
                Assert.AreEqual(expectedFirstname, actualFirstName,
                    "Неверное присвоение имени");
                var actualBirtDate = testContact.BirthDate;
                Assert.AreEqual(expectedBirthDate, actualBirtDate,
                    "Неверное присвоение даты рождения");
                var actualPhoneNumber = testContact.PhoneNumber;
                Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber,
                    "Неверное присвоение номера телефона");
                var actualEmail = testContact.Email;
                Assert.AreEqual(expectedEmail, actualEmail,
                    "Неверное присвоение электронной почты");
                var actualIDVK = testContact.IDVK;
                Assert.AreEqual(expectedIDVK, actualIDVK,
                    "Неверное присвоение IDVK");
            });

        }

        //TODO: именование
        [Test(Description = "Позитивный тест метода копирования")]
        public void TestContactClone_Correct()
        {
            var testContact = InitTestContact();

            Contact cloneContact = (Contact)testContact.Clone();
            //TODO: ты проверяешь равенство объектов только по ссылке, а надо проверять и правильность скопированных данных
            Assert.Multiple(() =>
            {
                Assert.AreEqual(cloneContact.Surname, testContact.Surname,
                    "Неверное копирование фамилии");
                Assert.AreEqual(cloneContact.Firstname, testContact.Firstname,
                    "Неверное копирование имени");
                Assert.AreEqual(cloneContact.BirthDate, testContact.BirthDate,
                    "Неверное копирование даты рождения");
                Assert.AreEqual(cloneContact.PhoneNumber.Digits,
                     testContact.PhoneNumber.Digits, "Неверное копирование номера телефона");
                Assert.AreEqual(cloneContact.Email, testContact.Email,
                    "Неверное копирование электронной почты");
                Assert.AreEqual(cloneContact.IDVK, testContact.IDVK,
                    "Неверное копирование IDVK");
            });
        }
    }
}
