using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace ContactsAppUI
{
    //TODO: сделать ссылки работающими
    //Я пытался сделать открытие стандратного браузера с заполненной формой
    //для написания письма мне на почту, но там как-то сложно с протоколами для 
    //для каждой почты и вообще... Мне всё-таки сделать почту кликабельной?
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.
                Start("https://mail.google.com/mail/u/0/#inbox?compose=new");
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
