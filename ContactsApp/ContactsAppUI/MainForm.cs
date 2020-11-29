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
    //TODO: переименовать в MainForm - это облегчает навигацию по проекту
    public partial class MainForm : Form
    {
        const string birthdaysStringStart = "Сегодня празднуют свой день рождения:\n";
        /// <summary>
        /// Поле для хранения всех контактов во время работы
        /// </summary>
        private Project _project = new Project();

        //TODO: Почему Used? Это не "используемые контакты", а "отображаемые контакты"
        /// <summary>
        /// Поле для хранения списка контактов, отображамых в левой панели
        /// </summary>
        private List<Contact> _displayedContacts;

        public MainForm()
        {
            //TODO: любые действия в контсрукторе должны быть после InitializeComponent(), иначе рискуешь потерять верстку
            InitializeComponent();
            contactDisplay1.IsReadOnly = true;
            var loadProject = ProjectManager.LoadFromFile(ProjectManager.DefaultFilePath);

            //TODO: после загрузки null не должен возвращаться ни в коем случае, только пустой проект
            if (loadProject.Contacts.Count > 0)
            {
                _project = loadProject;
                _displayedContacts = _project.SortBySurname();
                ShowListBoxItems(_displayedContacts);
            }
            ShowBirthdays();
        }

        /// <summary>
        /// Отображает выбранный в списке контакт в правой части
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedIndex != -1)
            {
                var selectedContact = _displayedContacts[contactsListBox.SelectedIndex];
                contactDisplay1.DisplayedContact = selectedContact;
            }
            else
            {
                contactDisplay1.DisplayedContact = null;
            }
        }

        //TODO: НЕЛЬЗЯ подписывать обработчики кнопки на события toolStripMenuItem! Это должны быть РАЗНЫЕ обработчики, так как им обоим приходят РАЗНЫЕ объекты в качестве sender и EventArgs e)!!!
        //      Сделать разные обработчики, которые вызывают один и тот же общий метод!
        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Добавляет в список новый контакт
        /// </summary>
        private void AddContact()
        {
            //TODO: просто так пустых строк быть не должно
            var addContactForm = new ContactForm();

            if (addContactForm.ShowDialog() == DialogResult.OK)
            {
                //TODO: грам.ошибки
                var newContact = addContactForm.Contact;

                _project.Contacts.Add(newContact);
                contactsListBox.Items.Add(newContact.Surname);

                _displayedContacts = _project.SortBySurname();
                ShowListBoxItems(_displayedContacts);
                ShowBirthdays();
                contactSearchTextBox.Clear();
                SelectFirstContact();
            }
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void EditContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Выполняет редактирования выбранного в списке контакта
        /// </summary>
        private void EditContact()
        {
            if (contactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Для редактирования необходимо выбрать контакт в списке",
                    "Error");
            }
            else
            { //TODO: табуляция поплыла
                var selectedContact = _displayedContacts[contactsListBox.SelectedIndex];
                ContactForm editContactForm = new ContactForm
                {
                    Contact = selectedContact
                };
                editContactForm.ShowDialog(); //TODO: грам. ошибки

                if (editContactForm.DialogResult != DialogResult.Cancel)
                {
                    var editedConact = editContactForm.Contact;

                    _project.Contacts.Add(editedConact);
                    contactsListBox.Items.Add(editedConact.Surname);
                    _project.Contacts.Remove(selectedContact);
                    contactsListBox.Items.Remove(selectedContact.Surname);

                    _displayedContacts = _project.SortBySurname();
                    ShowListBoxItems(_displayedContacts);
                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultFilePath);
                    ShowBirthdays();
                    contactSearchTextBox.Clear();
                    SelectFirstContact();
                }
            }
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void RemoveContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Удаляет выбранный в списке контакт
        /// </summary>
        private void RemoveContact()
        {
            if (contactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Для удаления необходимо выбрать контакт в списке",
                    "Error");
            }
            else
            {
                var selectedContact = _displayedContacts[contactsListBox.SelectedIndex];
                DialogResult result = MessageBox.Show("Do you really want to remove this contact: "
                    + selectedContact.Surname, "Error", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    _project.Contacts.Remove(selectedContact);
                    _displayedContacts.RemoveAt(contactsListBox.SelectedIndex);
                    contactsListBox.Items.
                        RemoveAt(contactsListBox.SelectedIndex);

                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultFilePath);
                    contactSearchTextBox.Clear();
                    ShowBirthdays();
                    SelectFirstContact();
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutInfo = new AboutForm();
            aboutInfo.ShowDialog();
        }

        private void ContactsAppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           ProjectManager.SaveToFile(_project, ProjectManager.DefaultFilePath);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Вывод контаков в левую панель
        /// </summary>
        /// <param name="contacts">Список контактов для отображения</param>
        private void ShowListBoxItems(List<Contact> contacts)
        {
            contactsListBox.Items.Clear();

            for (int i = 0; i < contacts.Count; i++)
            {
                contactsListBox.Items.Add(contacts[i].Surname);
            }
        }

        /// <summary>
        /// Ввод подстроки в текстовое поле для поиска
        /// </summary>
        private void ContactSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            _displayedContacts = _project.SortBySurname(contactSearchTextBox.Text);

            if (_displayedContacts.Count == _project.Contacts.Count)
            {
                _displayedContacts = _project.SortBySurname();
            }

            ShowListBoxItems(_displayedContacts);
            SelectFirstContact();
        }

        void SelectFirstContact()
        {
            if (_displayedContacts.Count > 0)
            {
                contactsListBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Вывод информационной панели с именинниками
        /// </summary>
        public void ShowBirthdays()
        {
            //TODO: грамошибки
            var birthdays = _project.FindBirthdays(DateTime.Now);

            if (birthdays.Count != 0)
            {
                //TODO: вынести в константу или в ресурсы проекта
                //TODO: разберись со статическими методами класса string - там есть готовый метод
                //TODO: плюс LINQ-запрос на получение списка фамилий из списка контактов
                var birthdaysSurnames = from contact in birthdays
                                  select contact;
                
                string birthdaysString = null;

                foreach (Contact line in birthdaysSurnames)
                {
                    birthdaysString += line.Surname.Insert(line.Surname.Length, ", ");
                }
                
                birthdaysString = birthdaysString.Insert(0, birthdaysStringStart);
                char[] charsToTrim = { ',', ' ' };
                birtdaysTextBox.Text = birthdaysString.TrimEnd(charsToTrim);
            }
            else
            {
                birthdayPanel.Visible = false;
            }
        }
    }
}
