using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using NUnit.Framework;


namespace ContactsAppUnitTests
{
    //TODO: модификатор доступа надо прописывать явно у всех классов
    [TestFixture]
    public class PhoneNumberTests
    {
        //TODO: опять - не надо работать через поля
        public PhoneNumber InitTestPhoneNumber()
        {
            var testPhoneNumber = new PhoneNumber(71234567890);
            return testPhoneNumber;
        }

        //TODO: негативные тесты сделать через TestCase
        [TestCase(81234567890,Description = "Неправильная первая цифра номера")]
        [TestCase(712345678901,Description = "Неправильное количество цифр в номере")]
        [TestCase(7123456789, Description = "Неправильное количество цифр в номере")]
        [Test(Description = "Негативный тест на сеттер с неправильными цифрами номера")]
        public void TestDigitsSet_DigitsUncorrect(Int64 wrongDigits)
        {
            var testPhoneNumber = InitTestPhoneNumber();

            Assert.Throws<Exception>(() =>
            { testPhoneNumber.Digits = wrongDigits; },
            "Возникает, если цифры номера некорректны");
        }

        [Test(Description = "Позитивный тест конструктора Contact")]
        public void TestPhoneNumberConstructor_CorrectValues()
        {
            var testPhoneNumber = InitTestPhoneNumber();

            var expectedDigits = 79998877666;
            testPhoneNumber.Digits = expectedDigits;
            var actualDigits = testPhoneNumber.Digits;

            Assert.AreEqual(expectedDigits, actualDigits, "Неверное присвоение цифр номера");
        }
    }
}
