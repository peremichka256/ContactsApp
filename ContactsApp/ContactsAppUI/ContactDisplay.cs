using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    //TODO: имя класса контрола должно в конце быть слово Control. Во-вторых, зачем здесь слово Display
    public partial class ContactDisplay : UserControl
    {
        //TODO: просто _contact
        /// <summary>
        /// Поле хранящее редактируемый или создаваемый объект
        /// </summary>
        private Contact _displayedСontact;

        //TODO: просто Contact
        /// <summary>
        /// Возвращает/задёт редактируемый или создаваемый объект
        /// </summary>
        public Contact DisplayedContact
        {
            get
            {
                return _displayedСontact;
            }

            set
            {
                this._displayedСontact = value;

                if (_displayedСontact != null)
                {
                    surnameTextBox.Text = _displayedСontact.Surname;
                    firstnameTextBox.Text = _displayedСontact.Firstname;
                    bithdateTimePicker.Value = _displayedСontact.BirthDate;
                    phoneNumberTextBox.Text = "+" 
                        + _displayedСontact.PhoneNumber.Digits.ToString();
                    emailTextBox.Text = _displayedСontact.Email;
                    iDVKTextBox.Text = _displayedСontact.IDVK;
                }
                else
                {
                    //TODO: у тебя конструктор контакта создает пустые строки в полях. Ты мог бы их присваивать из контакта -> избавиться от дублирования в ветках if-else
                    _displayedСontact = new Contact();
                    surnameTextBox.Text = null;
                    firstnameTextBox.Text = null;
                    bithdateTimePicker.Value = DateTime.Now;
                    phoneNumberTextBox.Text = null;
                    emailTextBox.Text = null;
                    iDVKTextBox.Text = null;
                }
            }
        }

        public ContactDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Поле хранящее значение об необходимом отображении информации
        /// </summary>
        private bool _isReadOnly;

        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }

            set
            {
                _isReadOnly = value;
                surnameTextBox.ReadOnly = _isReadOnly;
                firstnameTextBox.ReadOnly = _isReadOnly;
                bithdateTimePicker.Value = DateTime.Now;
                phoneNumberTextBox.ReadOnly = _isReadOnly;
                emailTextBox.ReadOnly = _isReadOnly;
                iDVKTextBox.ReadOnly = _isReadOnly;

                if (_isReadOnly)
                {
                    SetValidatedStyle(surnameTextBox);
                    SetValidatedStyle(firstnameTextBox);
                    SetValidatedStyle(phoneNumberTextBox);
                    SetValidatedStyle(emailTextBox);
                    SetValidatedStyle(iDVKTextBox);
                }
            }
        }

        /// <summary>
        /// Устанавливает стиль для неправильного проверяемого значения
        /// </summary>
        private void SetValidatingStyle(TextBox textBox)
        {
            textBox.BackColor = Color.LightSalmon;
        }

        /// <summary>
        /// Устанавливает стиль для проверенного значения
        /// </summary>
        private void SetValidatedStyle(TextBox textBox)
        {
            textBox.BackColor = Color.White;
        }

        private void PhoneNumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            int digitsNumber = 0;
            int firstDigit = 0;

            try
            {
                var phoneNumberDigits = long.Parse(phoneNumberTextBox.Text);
                digitsNumber = (int)Math.Log10(phoneNumberDigits) + 1;
                firstDigit = (int)(phoneNumberDigits
                    / Math.Pow(10, (int)Math.Log10(phoneNumberDigits)));
            }
            catch (Exception)
            {
                e.Cancel = true;
            }

            if ((digitsNumber != 11) || (firstDigit != 7))
            {
                SetValidatingStyle(phoneNumberTextBox);
                MessageBox.Show("Номер должен начинаться с '7' и иметь 11 цифр",
                     "Error");
                e.Cancel = true;
            }

        }

        private void PhoneNumberTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(phoneNumberTextBox);
            _displayedСontact.PhoneNumber = new PhoneNumber(long.Parse(phoneNumberTextBox.Text));
        }

        private void SurnameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((surnameTextBox.Text.Length > 50))
            {
                SetValidatingStyle(surnameTextBox);
                MessageBox.Show("Значение должно быть не больше 50 символов",
                     "Error");
                e.Cancel = true;
            }
        }

        private void SurnameTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(surnameTextBox);
            _displayedСontact.Surname = surnameTextBox.Text;
        }

        private void FirstnameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((firstnameTextBox.Text.Length > 50))
            {
                SetValidatingStyle(firstnameTextBox);
                MessageBox.Show("Значение должно быть не больше 50 символов",
                     "Error");
                e.Cancel = true;
            }
        }

        private void FirstnameTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(firstnameTextBox);
            _displayedСontact.Firstname = firstnameTextBox.Text;
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

        private void BithdateTimePicker_Validated(object sender, EventArgs e)
        {
            _displayedСontact.BirthDate = bithdateTimePicker.Value;
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((emailTextBox.Text.Length > 50))
            {
                SetValidatingStyle(emailTextBox);
                MessageBox.Show("Значение должно быть не больше 50 символов",
                     "Error");
                e.Cancel = true;
            }
        }

        private void EmailTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(emailTextBox);
            _displayedСontact.Email = emailTextBox.Text;
        }

        private void IDVKTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((iDVKTextBox.Text.Length > 15))
            {
                SetValidatingStyle(iDVKTextBox);
                MessageBox.Show("Значение должно быть не больше 50 символов",
                     "Error");
                e.Cancel = true;
            }
        }

        private void IDVKTextBox_Validated(object sender, EventArgs e)
        {
            SetValidatedStyle(iDVKTextBox);
            _displayedСontact.IDVK = iDVKTextBox.Text;
        }

        //TODO: Не корректное название. Надо называть IsCorrect или (чаще) HasErrors
        public bool IsDataFilledIn()
        {
            return !((surnameTextBox.Text == "") || (firstnameTextBox.Text == "")
                   || (phoneNumberTextBox.Text == ""));
        }
    }
}
