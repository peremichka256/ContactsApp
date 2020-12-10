namespace ContactsAppUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ContactsApp.Contact contact1 = new ContactsApp.Contact();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addContactButton = new System.Windows.Forms.ToolStripButton();
            this.editContactButton = new System.Windows.Forms.ToolStripButton();
            this.removeContactButton = new System.Windows.Forms.ToolStripButton();
            this.contactSearchTextBox = new System.Windows.Forms.TextBox();
            this.contactsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contactControl1 = new ContactsAppUI.ContactControl();
            this.birthdayPanel = new System.Windows.Forms.Panel();
            this.birthdayInfoPicture = new System.Windows.Forms.PictureBox();
            this.birtdaysTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.birthdayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.birthdayInfoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDropDownButton,
            this.editDropDownButton,
            this.helpDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(591, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileDropDownButton
            // 
            this.fileDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileDropDownButton.Name = "fileDropDownButton";
            this.fileDropDownButton.ShowDropDownArrow = false;
            this.fileDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.fileDropDownButton.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editDropDownButton
            // 
            this.editDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editContactsToolStripMenuItem,
            this.removeContactToolStripMenuItem});
            this.editDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editDropDownButton.Name = "editDropDownButton";
            this.editDropDownButton.ShowDropDownArrow = false;
            this.editDropDownButton.Size = new System.Drawing.Size(31, 22);
            this.editDropDownButton.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem.Text = "Add Contact";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // editContactsToolStripMenuItem
            // 
            this.editContactsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editContactsToolStripMenuItem.Name = "editContactsToolStripMenuItem";
            this.editContactsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.editContactsToolStripMenuItem.Text = "Edit Contact";
            this.editContactsToolStripMenuItem.Click += new System.EventHandler(this.EditContactsToolStripMenuItem_Click);
            // 
            // removeContactToolStripMenuItem
            // 
            this.removeContactToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeContactToolStripMenuItem.Name = "removeContactToolStripMenuItem";
            this.removeContactToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeContactToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.removeContactToolStripMenuItem.Text = "Remove Contact";
            this.removeContactToolStripMenuItem.Click += new System.EventHandler(this.RemoveContactToolStripMenuItem_Click);
            // 
            // helpDropDownButton
            // 
            this.helpDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.helpDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpDropDownButton.Name = "helpDropDownButton";
            this.helpDropDownButton.ShowDropDownArrow = false;
            this.helpDropDownButton.Size = new System.Drawing.Size(36, 22);
            this.helpDropDownButton.Text = "Help";
            this.helpDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.helpToolStripMenuItem.Text = "About";
            this.helpToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.contactSearchTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.contactsListBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.contactControl1);
            this.splitContainer1.Panel2.Controls.Add(this.birthdayPanel);
            this.splitContainer1.Panel2MinSize = 203;
            this.splitContainer1.Size = new System.Drawing.Size(591, 305);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 7;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactButton,
            this.editContactButton,
            this.removeContactButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 280);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(180, 25);
            this.toolStrip2.TabIndex = 48;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // addContactButton
            // 
            this.addContactButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addContactButton.Image = ((System.Drawing.Image)(resources.GetObject("addContactButton.Image")));
            this.addContactButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new System.Drawing.Size(23, 22);
            this.addContactButton.Text = "Add Contact";
            this.addContactButton.Click += new System.EventHandler(this.AddContactButton_Click);
            // 
            // editContactButton
            // 
            this.editContactButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editContactButton.Image = ((System.Drawing.Image)(resources.GetObject("editContactButton.Image")));
            this.editContactButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editContactButton.Name = "editContactButton";
            this.editContactButton.Size = new System.Drawing.Size(23, 22);
            this.editContactButton.Text = "Edit Contact";
            this.editContactButton.Click += new System.EventHandler(this.EditContactButton_Click);
            // 
            // removeContactButton
            // 
            this.removeContactButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeContactButton.Image = ((System.Drawing.Image)(resources.GetObject("removeContactButton.Image")));
            this.removeContactButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeContactButton.Name = "removeContactButton";
            this.removeContactButton.Size = new System.Drawing.Size(23, 22);
            this.removeContactButton.Text = "Remove Contact";
            this.removeContactButton.Click += new System.EventHandler(this.RemoveContactButton_Click);
            // 
            // contactSearchTextBox
            // 
            this.contactSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactSearchTextBox.Location = new System.Drawing.Point(45, 9);
            this.contactSearchTextBox.Name = "contactSearchTextBox";
            this.contactSearchTextBox.Size = new System.Drawing.Size(132, 20);
            this.contactSearchTextBox.TabIndex = 47;
            this.contactSearchTextBox.TextChanged += new System.EventHandler(this.ContactSearchTextBox_TextChanged);
            // 
            // contactsListBox
            // 
            this.contactsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactsListBox.FormattingEnabled = true;
            this.contactsListBox.Location = new System.Drawing.Point(12, 35);
            this.contactsListBox.Name = "contactsListBox";
            this.contactsListBox.Size = new System.Drawing.Size(165, 225);
            this.contactsListBox.TabIndex = 45;
            this.contactsListBox.SelectedIndexChanged += new System.EventHandler(this.ContactsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Find:";
            // 
            // contactControl1
            // 
            this.contactControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            contact1.BirthDate = new System.DateTime(2020, 12, 3, 10, 41, 0, 273);
            contact1.Email = "";
            contact1.Firstname = "";
            contact1.IDVK = "";
            contact1.PhoneNumber = null;
            contact1.Surname = "";
            this.contactControl1.Contact = contact1;
            this.contactControl1.IsReadOnly = false;
            this.contactControl1.Location = new System.Drawing.Point(3, 3);
            this.contactControl1.Name = "contactControl1";
            this.contactControl1.Size = new System.Drawing.Size(401, 221);
            this.contactControl1.TabIndex = 46;
            // 
            // birthdayPanel
            // 
            this.birthdayPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.birthdayPanel.Controls.Add(this.birthdayInfoPicture);
            this.birthdayPanel.Controls.Add(this.birtdaysTextBox);
            this.birthdayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.birthdayPanel.Location = new System.Drawing.Point(0, 230);
            this.birthdayPanel.Name = "birthdayPanel";
            this.birthdayPanel.Size = new System.Drawing.Size(407, 75);
            this.birthdayPanel.TabIndex = 45;
            // 
            // birthdayInfoPicture
            // 
            this.birthdayInfoPicture.Image = ((System.Drawing.Image)(resources.GetObject("birthdayInfoPicture.Image")));
            this.birthdayInfoPicture.Location = new System.Drawing.Point(12, 14);
            this.birthdayInfoPicture.Name = "birthdayInfoPicture";
            this.birthdayInfoPicture.Size = new System.Drawing.Size(47, 49);
            this.birthdayInfoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.birthdayInfoPicture.TabIndex = 1;
            this.birthdayInfoPicture.TabStop = false;
            // 
            // birtdaysTextBox
            // 
            this.birtdaysTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.birtdaysTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.birtdaysTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.birtdaysTextBox.Location = new System.Drawing.Point(65, 14);
            this.birtdaysTextBox.Name = "birtdaysTextBox";
            this.birtdaysTextBox.ReadOnly = true;
            this.birtdaysTextBox.Size = new System.Drawing.Size(309, 49);
            this.birtdaysTextBox.TabIndex = 0;
            this.birtdaysTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 330);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(419, 310);
            this.Name = "MainForm";
            this.Text = "ContactsApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContactsAppForm_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.birthdayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.birthdayInfoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton addContactButton;
        private System.Windows.Forms.ToolStripButton editContactButton;
        private System.Windows.Forms.ToolStripButton removeContactButton;
        private System.Windows.Forms.TextBox contactSearchTextBox;
        private System.Windows.Forms.ListBox contactsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripDropDownButton fileDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton editDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton helpDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeContactToolStripMenuItem;
        private System.Windows.Forms.Panel birthdayPanel;
        private System.Windows.Forms.RichTextBox birtdaysTextBox;
        private System.Windows.Forms.PictureBox birthdayInfoPicture;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private ContactControl contactControl1;
    }
}

