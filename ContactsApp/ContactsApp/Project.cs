using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactsApp
{
    public class Project
    {
        //TODO: автосвойство
        /// <summary>
        /// Доступ к списку всех контактов
        /// </summary>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Сортирует список контактов по фамилиям
        /// </summary>
        /// <returns>Отсортированный список контактов</returns>
        public List<Contact> SortBySurname()
        {
            if (Contacts.Count != 0)
            {
                return Contacts.OrderBy(contact => contact.Surname).ToList();
            }
            else
            {
                return Contacts;
            }
        }

        /// <summary>
        /// Сортирует список контактов по фамилиям с заданной подстрокой
        /// </summary>
        /// <param name="substring">Подстрока, по которой ищется элемент</param>
        /// <returns>Отсортированный список контактов с подстрокой</returns>
        public List<Contact> SortBySurname(string substring)
        {
            var foundContacts = new List<Contact>();

            for (int i = 0; i < Contacts.Count; i++)
            {
                //TODO: используй Contains
                if ((Contacts[i].Surname.Length >= substring.Length) 
                    && (Contacts[i].Surname.Contains(substring)))
                {
                    foundContacts.Add(Contacts[i]);
                }
            }

            return foundContacts;
        }

        public Project()
        {
            Contacts = new List<Contact>();
        }
    }
}
