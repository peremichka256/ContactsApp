using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactsApp
{
    public class Project
    {
        /// <summary>
        /// Список всех контактов, созданных в приложении
        /// </summary>
        private List<Contact> _contacts = new List<Contact>();

        //TODO: автосвойство
        /// <summary>
        /// Доступ к списку всех контактов
        /// </summary>
        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }

            set
            {
                _contacts = value;
            }
        }

        /// <summary>
        /// Сортирует список контактов по фамилиям
        /// </summary>
        /// <returns>Отсортированный список контактов</returns>
        public List<Contact> SortBySurname()
        {
            return _contacts.OrderBy(contact => contact.Surname).ToList();
        }

        /// <summary>
        /// Сортирует список контактов по фамилиям с заданной подстрокой
        /// </summary>
        /// <param name="substring">Подстрока, по которой ищется элемент</param>
        /// <returns>Отсортированный список контактов с подстрокой</returns>
        public List<Contact> SortBySurname(string substring)
        {
            var foundContacts = new List<Contact>();

            for (int i = 0; i < _contacts.Count; i++)
            {
                //TODO: используй Contains
                if ((_contacts[i].Surname.Length >= substring.Length) 
                    && (_contacts[i].Surname.Substring(0, substring.Length) == substring))
                {
                    foundContacts.Add(_contacts[i]);
                }
            }

            return foundContacts;
        }

        /// <summary>
        /// Поиск именинников в списке всех контактов
        /// </summary>
        /// <param name="birthDateTime">Дата относительно которой ищется именинник</param>
        /// <returns>Список именинников</returns>
        public List<Contact> FindBirthdays(DateTime birthDateTime)
        {
            var birtdayContacts = new List<Contact>();
            
            foreach (var contact in _contacts)
            {
                if((contact.BirthDate.Month == birthDateTime.Month)
                    && (contact.BirthDate.Day == birthDateTime.Day))
                {
                    birtdayContacts.Add(contact);
                }
            }

            return birtdayContacts;
        }
    }
}
