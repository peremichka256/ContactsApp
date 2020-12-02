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
    public partial class ContactForm : Form
    {
        //TODO: зачем на форме хранить контакт, если он и так хранится в контроле? Просто прокидывай контакт до контрола и также забирай обратно
        /// <summary>
        /// Поле хранящее редактируемый или создаваемый объект
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Возвращает/задёт редактируемый или создаваемый объект
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }

            set
            {
                _contact = value;
                if (_contact != null)
                { //TODO: именование контакта исправить
                    contactDisplay1.DisplayedContact = _contact;
                }
            }
        }

        /// <summary>
        /// Конструткор по умолчанию при добавлении контакта
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            contactDisplay1.IsReadOnly = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!contactDisplay1.IsDataFilledIn())
            {
                MessageBox.Show("Обязательные поля должны быть заполнены",
                     "Error");
            }
            else
            {
                _contact = contactDisplay1.DisplayedContact;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
