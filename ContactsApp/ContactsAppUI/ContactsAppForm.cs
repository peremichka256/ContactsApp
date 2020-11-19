//TODO: убрать булеву слепоту
//TODO: допилить функционал и тесты на него
//TODO: сборщик установщика
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
    public partial class ContactsAppForm : Form
    {
        /// <summary>
        /// Поле для хранения всех контактов во время работы
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Поле для хранения списка контактов, отображамых в левой панели
        /// </summary>
        private List<Contact> _usedContacts;

        public ContactsAppForm()
        {
            var loadProject = ProjectManager.LoadFromFile(ProjectManager.DefaultFilePath);

            InitializeComponent();

            if (loadProject != null)
            {
                _project = loadProject;
                _usedContacts = _project.SortBySurname();

                ShowListBoxItems(_usedContacts);
                ShowBirthdays();
            }
        }

        /// <summary>
        /// Отображает выбранный в списке контакт в правой части
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedIndex > -1)
            {
                var selectedcontactIndex = contactsListBox.SelectedIndex;

                surnameTextBox.Text = _usedContacts[selectedcontactIndex].Surname;
                firstnameTextBox.Text = _usedContacts[selectedcontactIndex].Firstname;
                birthdayDate.Value = _usedContacts[selectedcontactIndex].BirthDate;
                phoneNumberTextBox.Text = "+" 
                    + _usedContacts[selectedcontactIndex].PhoneNumber.Digits.ToString();
                emailTextBox.Text = _usedContacts[selectedcontactIndex].Email;
                iDVKTextBox.Text = _usedContacts[selectedcontactIndex].IDVK;
            }
            else
            {
                surnameTextBox.Text = null;
                firstnameTextBox.Text = null;
                birthdayDate.Value = DateTime.Now;
                phoneNumberTextBox.Text = null;
                emailTextBox.Text = null;
                iDVKTextBox.Text = null;
            }
        }

        /// <summary>
        /// Добавляет в список новый контакт
        /// </summary>
        private void AddContactButton_Click(object sender, EventArgs e)
        {

            var addContactForm = new AddEditContactForm();

            if (addContactForm.ShowDialog() == DialogResult.OK)
            {
                var newConatct = addContactForm.Contact;
                _project.Contacts.Add(newConatct);
                contactsListBox.Items.Add(newConatct.Surname);

                _usedContacts = _project.SortBySurname();
                ShowListBoxItems(_usedContacts);
            }
        }

        /// <summary>
        /// Выполняет редактирования выбранного в списке контакта
        /// </summary>
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Для редактирования необходимо выбрать контакт в списке",
                    "Error");
            }
            else
            {
               var editContactForm =
                   new AddEditContactForm(_usedContacts[contactsListBox.SelectedIndex]);
               editContactForm.ShowDialog();
               var editedConact = editContactForm.Contact;

               _project.Contacts.Add(editedConact);
               contactsListBox.Items.Add(editedConact.Surname);
               _project.Contacts.Remove(_usedContacts[contactsListBox.SelectedIndex]);
               contactsListBox.Items.Remove(_usedContacts[contactsListBox.SelectedIndex].Surname);

                _usedContacts = _project.SortBySurname();
                ShowListBoxItems(_usedContacts);
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultFilePath);
            }
        }

        /// <summary>
        /// Удаляет выбранный в списке контакт
        /// </summary>
        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Для удаления необходимо выбрать контакт в списке",
                    "Error");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you really want to remove this contact: "
                    + _usedContacts[contactsListBox.SelectedIndex].Surname,
                      "Error", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    _project.Contacts.Remove(_usedContacts[contactsListBox.SelectedIndex]);
                    _usedContacts.RemoveAt(contactsListBox.SelectedIndex);
                    contactsListBox.Items.
                        RemoveAt(contactsListBox.SelectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultFilePath);
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
            _usedContacts = _project.SortBySurname(contactSearchTextBox.Text);

            if (_usedContacts.Count == _project.Contacts.Count)
            {
                _usedContacts = _project.SortBySurname();
            }

            ShowListBoxItems(_usedContacts);
            contactsListBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Вывод информационной панели с именинниками
        /// </summary>
        public void ShowBirthdays()
        {
            var birtdays = _project.FindBirthdays(DateTime.Now);

            if (birtdays.Count != 0)
            {
                var birthdaysString = "Сегодня празднуют свой день рождения:\n";

                for (int i = 0; i < birtdays.Count; i++)
                {
                    birthdaysString += birtdays[i].Surname + ", ";
                }
                birtdaysTextBox.Text = birthdaysString.Trim();
            }
            else
            {
                birthdayPanel.Visible = false;
            }
        }
    }
}
