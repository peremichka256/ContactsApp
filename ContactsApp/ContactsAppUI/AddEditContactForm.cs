﻿using System;
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
    //TODO: не надо перечислять глаголы в названии формы. Просто ContactForm - форма, предназначенная для работы с одним контактом
    public partial class AddEditContactForm : Form
    {
        /// <summary>
        /// Возвращает или задёт редактируемый или создаваемый объект
        /// </summary>
        private Contact _contact;

        //TODO: xml
        //TODO: автосвойство?
        public Contact Contact
        {
            get
            {
                return _contact;
            }

            set
            {
                this._contact = value;
            }
        }

        /// <summary>
        /// Конструткор по умолчанию при добавлении контакта
        /// </summary>
        public AddEditContactForm()
        {
            InitializeComponent();
        }

        //TODO: Нет! Конструктор должен быть один и без параметра. А взаимодействие с формой осуществляется только через свойство Contact
        /// <summary>
        /// Конструктор при изменении существуюшего контакта
        /// </summary>
        /// <param name="contact">Передаваемый для редактирования контакт</param>
        public AddEditContactForm(Contact contact)
        {
            InitializeComponent();

            Contact = contact;

            surnameTextBox.Text = _contact.Surname;
            firstnameTextBox.Text = _contact.Firstname;
            bithdateTimePicker.Value = _contact.BirthDate;
            phoneNumberTextBox.Text = "+"
                    + _contact.PhoneNumber.Digits.ToString();
            emailTextBox.Text = _contact.Email;
            iDVKTextBox.Text = _contact.IDVK;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if ((surnameTextBox.Text == "") || (firstnameTextBox.Text == "")
                || (phoneNumberTextBox.Text == "") || (emailTextBox.Text == "")
                || (iDVKTextBox.Text == ""))
            {
                MessageBox.Show("Все поля должны быть заполнены",
                     "Error");
            }
            else
            {
                _contact = new Contact(surnameTextBox.Text,
                    firstnameTextBox.Text,
                    new PhoneNumber(long.Parse(phoneNumberTextBox.Text)),
                    bithdateTimePicker.Value,
                    emailTextBox.Text,
                    iDVKTextBox.Text = iDVKTextBox.Text
                    );
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PhoneNumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //TODO: что за создание телефонного номера в никуда?
                new PhoneNumber(long.Parse(phoneNumberTextBox.Text));
            }
            catch (Exception)
            {
                //TODO: так как стили на ошибку везде задаются одинаковые, вынеси это в отдельный метод. Аналогично со стилями 
                phoneNumberTextBox.BackColor = Color.LightSalmon;
                e.Cancel = true;
            }
        }

        private void PhoneNumberTextBox_Validated(object sender, EventArgs e)
        {
            phoneNumberTextBox.BackColor = Color.White;
        }

        private void SurnameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((surnameTextBox.Text.Length > 50))
            {
                surnameTextBox.BackColor = Color.LightSalmon;
                e.Cancel = true;
            }
        }

        private void SurnameTextBox_Validated(object sender, EventArgs e)
        {
            surnameTextBox.BackColor = Color.White;
        }

        private void FirstnameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((firstnameTextBox.Text.Length > 50))
            {
                firstnameTextBox.BackColor = Color.LightSalmon;
                e.Cancel = true;
            }
        }

        private void FirstnameTextBox_Validated(object sender, EventArgs e)
        {
            firstnameTextBox.BackColor = Color.White;
        }

        //не смог сделать у timePickerа фон другого цвета,
        //поэтому решил выкидывать диалоговое окно
        private void BithdateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if ((bithdateTimePicker.Value > DateTime.Now)
                || (bithdateTimePicker.Value < Contact.MinBirthDate))
            {
                MessageBox.Show("Дата выбрана неправильно",
                   "Error");
                e.Cancel = true;
            }
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((emailTextBox.Text.Length > 50))
            {
                emailTextBox.BackColor = Color.LightSalmon;
                e.Cancel = true;
            }
        }

        private void EmailTextBox_Validated(object sender, EventArgs e)
        {
            emailTextBox.BackColor = Color.White;
        }

        private void IDVKTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((iDVKTextBox.Text.Length > 15))
            {
                iDVKTextBox.BackColor = Color.LightSalmon;
                e.Cancel = true;
            }
        }

        private void IDVKTextBox_Validated(object sender, EventArgs e)
        {
            iDVKTextBox.BackColor = Color.White;
        }
    }
}
