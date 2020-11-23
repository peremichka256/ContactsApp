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
    [TestFixture]
    public class ContactTest
    {
        private Contact _testContact;

        //TODO: не надо работать через поле - тогда тесты могут быть зависимы друг от друга. Сделай просто возвращаемое значение
        public void InitTestContact()
        {
            _testContact = new Contact(
                "TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877666),
                new DateTime(2000, 1, 1),
                "TestEmail",
                "TestiDVK");
        }

        [Test(Description = "Негативный тест сеттера Surname")]
        public void TestSurnameSet_UncorrectValue()
        {
            InitTestContact();

            Assert.Throws<Exception>(()=> 
            { _testContact.Surname = "WrongSurnameWrongSurnameWrongSurnameWrongSurnameWro"; },
            "Возникает, если длина больше 50 символов");
        }

        [Test(Description = "Негативный тест сеттера FirstName")]
        public void TestFirstnameSet_UncorrectValue()
        {
            InitTestContact();

            Assert.Throws<Exception>(() =>
            { _testContact.Firstname = "WrongFirstnameWrongFirstnameWrongFirstnameWrongFirs"; },
            "Возникает, если длина больше 50 символов");
        }

        [Test(Description = "Негативный тест сеттера Birthdate при дате меньше минимальной")]
        public void TestBirthDateSet_MoreCurrentDate()
        {
            InitTestContact();

            Assert.Throws<Exception>(() =>
            { _testContact.BirthDate = new DateTime(1899,12,31); },
            "Возникает, если дата меньше минимально доступной");
        }

        [Test(Description = "Негативный тест сеттера Birthdate при дате больше текущей")]
        public void TestBirthDateSet_LessMinDate()
        {
            InitTestContact();

            Assert.Throws<Exception>(() =>
            { _testContact.BirthDate = DateTime.MaxValue; },
            "Возникает, если дата больше максимально доступной");
        }

        [Test(Description = "Негативный тест сеттера Email")]
        public void TestEmailSet_UncorrectValue()
        {
            InitTestContact();

            Assert.Throws<Exception>(() =>
            { _testContact.Email = "WrongEmailWrongEmailWrongEmailWrongEmailWrongEmail1"; },
            "Возникает, если длина больше 50 символов");
        }

        [Test(Description = "Негативный тест сеттера IDVK")]
        public void TestIDVKSet_UncorrectValue()
        {
            InitTestContact();

            Assert.Throws<Exception>(() =>
            { _testContact.IDVK = "WrongIdWrongId12"; },
            "Возникает, если длина больше 15 символов");
        }

        //TODO: а где тесты конструктора с неправильными значениями?
        [Test(Description = "Позитивный тест конструктор Contact")]
        public void TestContactConstructor_CorrectValues()
        {
            InitTestContact();

            var expectedSurname = "Testsurname1";
            _testContact.Surname = expectedSurname;
            var expectedFirstname = "Testfirstname1";
            _testContact.Firstname = expectedFirstname;
            var expectedBirthDate = new DateTime(2000,1,1);
            _testContact.BirthDate = expectedBirthDate;
            var expectedPhoneNumber = new PhoneNumber(79998877667);
            _testContact.PhoneNumber = expectedPhoneNumber;
            var expectedEmail = "Testemail";
            _testContact.Email = expectedEmail;
            var expectedIDVK = "TestiDVK";
            _testContact.IDVK = expectedIDVK;

            var actualSurname = _testContact.Surname;
            //TODO: если в тесте больше одного Assert, тогда их надо объединять через Assert.Multiple()
            Assert.AreEqual(expectedSurname, actualSurname,
                "Неверное присвоение фамилии");
            var actualFirstName = _testContact.Firstname;
            Assert.AreEqual(expectedFirstname, actualFirstName,
                "Неверное присвоение имени");
            var actualBirtDate = _testContact.BirthDate;
            Assert.AreEqual(expectedBirthDate, actualBirtDate,
                "Неверное присвоение даты рождения");
            var actualPhoneNumber = _testContact.PhoneNumber;
            Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber,
                "Неверное присвоение номера телефона");
            var actualEmail = _testContact.Email;
            Assert.AreEqual(expectedEmail, actualEmail,
                "Неверное присвоение электронной почты");
            var actualIDVK = _testContact.IDVK;
            Assert.AreEqual(expectedIDVK, actualIDVK,
                "Неверное присвоение IDVK");

        }

        //TODO: именование
        [Test(Description = "Позитивный тест метода копирования")]
        public void TestContacClone_Object()
        {
            InitTestContact();

            Contact cloneContact = (Contact)_testContact.Clone();
            //TODO: ты проверяешь равенство объектов только по ссылке, а надо проверять и правильность скопированных данных
            Assert.AreNotSame(cloneContact, _testContact, "Элемент не скопирован");
        }
    }
}
