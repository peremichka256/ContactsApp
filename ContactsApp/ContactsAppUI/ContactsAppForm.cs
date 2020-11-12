//TODO: + в номере
//TODO: тесты
//TODO: сборка установщика
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
        /// Поле для хранения контактов во время работы
        /// </summary>
        private Project _project = new Project();

        public ContactsAppForm()
        {
            var loadProject = ProjectManager.LoadFromFile(ProjectManager.DefaultFilePath);

            InitializeComponent();

            if (loadProject!=null)
            {
                _project = loadProject;

                for (int i = 0; i < _project.Contacts.Count; i++)
                {
                    contactsListBox.Items.Add(_project.Contacts[i].Surname);
                }
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

                surnameTextBox.Text = _project.Contacts[selectedcontactIndex].Surname;
                firstnameTextBox.Text = _project.Contacts[selectedcontactIndex].Firstname;
                birthdayDate.Value = _project.Contacts[selectedcontactIndex].BirthDate;
                //TODO: добавь "+" в номере
                phoneNumberTextBox.Text
                    = _project.Contacts[selectedcontactIndex].PhoneNumber.Digits.ToString();
                emailTextBox.Text = _project.Contacts[selectedcontactIndex].Email;
                iDVKTextBox.Text = _project.Contacts[selectedcontactIndex].IDVK;
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
                   new AddEditContactForm(_project.Contacts[contactsListBox.SelectedIndex]);
               editContactForm.ShowDialog();
               var editedConact = editContactForm.Contact;

               _project.Contacts.Add(editedConact);
               contactsListBox.Items.Add(editedConact.Surname);
               _project.Contacts.Remove(_project.Contacts[contactsListBox.SelectedIndex]);
               contactsListBox.Items.RemoveAt(contactsListBox.SelectedIndex);
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
                    + _project.Contacts[contactsListBox.SelectedIndex].Surname,
                      "Error", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    _project.Contacts.Remove(_project.Contacts[contactsListBox.SelectedIndex]);
                    contactsListBox.Items.RemoveAt(contactsListBox.SelectedIndex);
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
    }
}
