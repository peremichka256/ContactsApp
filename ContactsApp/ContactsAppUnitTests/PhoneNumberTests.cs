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
    class PhoneNumberTests
    {
        private PhoneNumber _testPhoneNumber;

        public void InitTestPhoneNumber()
        {
            _testPhoneNumber = new PhoneNumber(71234567890);
        }

        [Test(Description = "Негативный тест на сеттер с неправильной первой цифрой")]
        public void TestDigitsSet_FirstDigitUncorrect()
        {
            InitTestPhoneNumber();

            Assert.Throws<Exception>(() =>
            { _testPhoneNumber.Digits = 81234567890; },
            "Возникает, если первая цифра не '7'");
        }

        [Test(Description = "Негативный тест на сеттер с количество цифр больше 11")]
        public void TestDigitsSet_More11Digits()
        {
            InitTestPhoneNumber();

            Assert.Throws<Exception>(() =>
            { _testPhoneNumber.Digits = 712345678901; },
            "Возникает, если количество цифр больше 11");
        }

        [Test(Description = "Позитивный тест конструктора Contact")]
        public void TestPhoneNumberConstructor_CorrectValues()
        {
            InitTestPhoneNumber();

            var expectedDigits = 79998877666;
            _testPhoneNumber.Digits = expectedDigits;

            var actualDigits = _testPhoneNumber.Digits;

            Assert.AreEqual(expectedDigits, actualDigits, "Неверное присвоение цифр номера");
        }
    }
}
