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
        /// Возвращает/задёт редактируемый или создаваемый объект
        /// </summary>
        public Contact Contact
        {
            get
            {
                return contactControl.Contact;
            }

            set
            { //TODO: именование контакта исправить
                contactControl.Contact = value;
            }
        }

        /// <summary>
        /// Конструткор по умолчанию при добавлении контакта
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            contactControl.IsReadOnly = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!contactControl.IsCorrect())
            {
                MessageBox.Show("Обязательные поля должны быть заполнены",
                     "Error");
            }
            else
            {
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
