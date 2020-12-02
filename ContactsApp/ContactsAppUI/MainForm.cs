using ContactsApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        //TODO: именование нарушает RSDN
        /// <summary>
        /// Начальная фраза в панели именинников
        /// </summary>
        const string birthdaysStringStart = "Сегодня празднуют свой день рождения:\n";

        /// <summary>
        /// Поле для хранения всех контактов во время работы
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Поле для хранения списка контактов, отображамых в левой панели
        /// </summary>
        private List<Contact> _displayedContacts;

        public MainForm()
        {
            InitializeComponent();
            contactDisplay1.IsReadOnly = true;
            var loadProject = ProjectManager.LoadFromFile(ProjectManager.DefaultFilePath);
            //TODO: а произойдет ли что-то страшное, если этого условия не будет, и код будет выполняться и для пустых проектов?
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
            var addContactForm = new ContactForm();

            if (addContactForm.ShowDialog() == DialogResult.OK)
            {
                var newContact = addContactForm.Contact;

                _project.Contacts.Add(newContact);
                contactsListBox.Items.Add(newContact.Surname);

                _displayedContacts = _project.SortBySurname();
                ShowListBoxItems(_displayedContacts);
                EditFormAfterChanges(); //TODO: нет пересохранения проекта
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
            {
                var selectedContact = _displayedContacts[contactsListBox.SelectedIndex];
                ContactForm editContactForm = new ContactForm
                {
                    Contact = selectedContact
                };
                editContactForm.ShowDialog();

                if (editContactForm.DialogResult != DialogResult.Cancel)
                { //TODO: еще раз!! Грамошибки
                    var editedConact = editContactForm.Contact;

                    _project.Contacts.Add(editedConact);
                    contactsListBox.Items.Add(editedConact.Surname);
                    _project.Contacts.Remove(selectedContact);
                    contactsListBox.Items.Remove(selectedContact.Surname);

                    _displayedContacts = _project.SortBySurname();
                    ShowListBoxItems(_displayedContacts);
                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultFilePath);
                    EditFormAfterChanges();
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
                    EditFormAfterChanges();
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
        //TODO: модификаторы доступа надо прописывать явно
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
            var birthdays = _project.FindBirthdays(DateTime.Now);

            if (birthdays.Count != 0)
            {
                //TODO: неправильно сделал. LINQ запрос может сразу забирать список фамилий, а у тебя забирает список контактов. По факту бесполезный LINQ. Кроме того, LINQ запрос можно сделать еще в самой первой строке этого метода
                //TODO: Во-вторых, смотри СТАТИЧЕСКИЕ методы класса string. TrimEnd - это не тот метод, который тебе здесь нужен. Всё можно заменить на две-три строчки кода
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
                birthdayPanel.Visible = true;
            }
            else
            {
                birthdayPanel.Visible = false;
            }
        }

        //TODO: Update, а не Edit. Редактирования окна здесь не происходит, только обновление данных
        /// <summary>
        /// Изменяет необходимые компоненты после изменения списка контактов
        /// </summary>
        private void EditFormAfterChanges()
        {
            ShowBirthdays();
            SelectFirstContact();
            contactSearchTextBox.Clear();
        }
    }
}
