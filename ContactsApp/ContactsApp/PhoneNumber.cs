using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactsApp
{
    /// <summary>
    /// Класс телефонного номера, хранящий числовое значение номера телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Численная переменная хранящая номер телефона
        /// </summary>
        private long _digits;

        /// <summary>
        /// Возвращает или задаёт номер телефона, размер ровно 11 цифр, первая цифра '7'
        /// </summary>
        public long Digits
        {
            get
            {
                return _digits;
            }

            set
            {
                //TODO: Count, а не Number. Особенно в контексте названия класса, неправильное использование слова
                var digitsNumber = (int)Math.Log10(value) + 1;
                var firstDigit = (int)(value / Math.Pow(10, (int)Math.Log10(value)));

                if ((digitsNumber != 11) || (firstDigit != 7))
                {
                    throw new Exception("Number of digits should be 11, and first digit is '7'");
                }
                _digits = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="digits">Цифры номера телефона</param>
        public PhoneNumber(long digits)
        {
            this.Digits = digits;
        }
    }
}
