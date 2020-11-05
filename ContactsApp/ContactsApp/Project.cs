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

        /// <summary>
        /// Доступ к списоку всех контактов
        /// </summary>
        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }
    }
}
