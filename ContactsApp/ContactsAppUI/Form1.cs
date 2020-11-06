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
    public partial class ContactsForm : Form
    {
        public ContactsForm()
        {
            var newProjectContacts = new Project();

            //Ранее были записаны данные, они успешно загружаются в переменную
            newProjectContacts = ProjectManager.LoadFromFile();

            //Загруженные данные успешно сохраняются
            ProjectManager.SaveToFile(newProjectContacts);

            InitializeComponent();
        }
    }
}
