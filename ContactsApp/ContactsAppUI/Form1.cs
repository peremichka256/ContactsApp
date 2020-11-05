using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactsForm : Form
    {
        public ContactsForm()
        {
            var newProjectContacts = new Project();

            try
            {
                var firstWrongContact = new Contact("белоУс", "Глеб", new PhoneNumber(89237574394),
                new DateTime(2001, 04, 11), "asd@mail.ru", "kek");
            }
            catch(Exception)
            {
                //Тут ошибка в первой цифре номера
            }

            try
            {
                var firstWrongContact = new Contact("белоУс", "Глеб", new PhoneNumber(89237574394),
                new DateTime(2001, 04, 11), "asd@mail.ru", "kek");
            }
            catch (Exception)
            {
                //Тут ошибка в количестве цифр номера
            }

            try
            {
                var firstWrongContact = new Contact("белоУс", "Глеб", new PhoneNumber(79237574394),
                new DateTime(1899, 04, 11), "asd@mail.ru", "ass");
            }
            catch (Exception)
            {
                //Тут ошибка в дате рождения
            }

            try
            {
                var firstWrongContact = new Contact("белоУс", "Глеб", new PhoneNumber(79237574394),
                new DateTime(2021, 04, 11), "asd@mail.ru", "kek");
            }
            catch (Exception)
            {
                //Тут ошибка в дате рождения
            }

            try
            {
                var firstWrongContact = new Contact("белоУс", "Глеб", new PhoneNumber(79237574394),
                new DateTime(2001, 04, 11),
                "asd@mail.ruasd@mail.ruasd@mail.ruasd@mail.ruasd@mail.ru", "kek");
            }
            catch (Exception)
            {
                //Тут ошибка в количестве символов в почте
            }

            var myContact = new Contact("белоУс", "Глеб", new PhoneNumber(79237574394),
                new DateTime(2001, 04, 11), "asd@mail.ru", "kek");

            var myFrendContact = new Contact("Иван", "иванов", new PhoneNumber(79237574994),
                new DateTime(2001, 04, 11), "asd@mail.ru", "kek");

            //Контакты заносятся в список, посмотрено через отладку
            newProjectContacts.Contacts.Add(myContact);
            newProjectContacts.Contacts.Add(myFrendContact);

            //проверка метода клонирования
            var myContactClone = myContact.Clone();

            InitializeComponent();
        }
    }
}
