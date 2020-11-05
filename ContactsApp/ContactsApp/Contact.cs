using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта, хранящий основную информацию, а именно Фамилию, Имя, 
    /// объект  класса номера телефона, дату рождения, email и id ВКонтакте
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя
        /// </summary>
        private string _firstname;

        /// <summary>
        /// Номер телефона
        /// </summary>
        private PhoneNumber _phoneNumber;

        ///<summary>
        /// Дата рождения
        ///</summary>
        private DateTime _birthDate;

        ///<summary>
        /// Электронная почта
        ///</summary>
        private string _email;

        ///<summary>
        /// ID ВКонтакте
        ///</summary>
        private string _iDVK;

        /// <summary>
        /// Возвращает или задаёт фамилию, длина не больше 50, первая буква большая
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                if (value.Length > 50)
                {
                    throw
                        new Exception("Length of surname shuld be less than 50 symbols");
                }

                string[] surnameString = value.Split(' ');

                for (int i = 0; i < surnameString.Length; i++)
                {
                    if (surnameString[i].Length > 1)
                        surnameString[i] = surnameString[i].Substring(0, 1).ToUpper()
                            + surnameString[i].Substring(1, surnameString[i].Length - 1).ToLower();
                    else surnameString[i] = surnameString[i].ToUpper();
                }

                _surname = string.Join("", surnameString);
            }
        }

        /// <summary>
        /// Возвращает или задаёт имя, длина не больше 50, первая буква большая
        /// </summary>
        public string Firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                if (value.Length > 50)
                {
                    throw
                        new Exception("Length of first name shuld be less than 50 symbols");
                }

                string[] firstnameString = value.Split(' ');

                for (int i = 0; i < firstnameString.Length; i++)
                {
                    if (firstnameString[i].Length > 1)
                        firstnameString[i] = firstnameString[i].Substring(0, 1).ToUpper()
                            + firstnameString[i].Substring(1, firstnameString[i].Length - 1).ToLower();
                    else firstnameString[i] = firstnameString[i].ToUpper();
                }

                _firstname = string.Join("", firstnameString);
            }
        }

        /// <summary>
        /// Возвращает или задаёт номер телефона
        /// </summary>
        public PhoneNumber PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт дату рождаения, дата не больше текущей и не 
        /// меньше 1900-го года
        /// </summary>
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }

            set
            {
                var minBirthDate = new DateTime(1900, 1, 1);

                if ((value > DateTime.Now) && (value > minBirthDate))
                {
                    throw new Exception
                        ("BirthDate should be not less than 1900 and no more current year");
                }
                _birthDate = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт электронную почту, длина не более 50 символов
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (value.Length > 50)
                {
                    throw
                        new Exception("Length of email name should be less than 50 symbols");
                }

                _email = value;
            }
        }

        /// <summary>
        /// Вовзращает или задаёт ID ВКонтакте, состоит не более чем из 15 символов
        /// </summary>
        public string IDVK
        {
            get
            {
                return _iDVK;
            }

            set
            {
                if (value.Length > 15) 
                {
                    throw new Exception("Id has a length not more than 15 symbols");
                }
                _iDVK = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="firstname">Имя</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="iDVK">ID ВКонтакте</param>
        public Contact(string surname, string firstname, PhoneNumber phoneNumber,
            DateTime birthDate, string email, string iDVK)
        {
            this.Surname = surname;
            this.Firstname = firstname;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
            this.Email = email;
            this.IDVK = iDVK;
        }

        /// <summary>
        /// Реализация интерфейса IClone
        /// </summary>
        /// <returns>Возвращает новый объект-копию текущего объекта</returns>
        public object Clone()
        {
            return new Contact(this._surname,
                this._firstname,
                this._phoneNumber,
                this._birthDate,
                this._email,
                this._iDVK);
        }
    }
}
