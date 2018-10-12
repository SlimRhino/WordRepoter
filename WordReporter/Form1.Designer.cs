namespace WordReporter
{
    partial class Form1
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
            this.guidGenBtn = new System.Windows.Forms.Button();
            this.defGuidBtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.openInWordBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.guid = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // guidGenBtn
            // 
            this.guidGenBtn.Enabled = false;
            this.guidGenBtn.Location = new System.Drawing.Point(20, 136);
            this.guidGenBtn.Name = "guidGenBtn";
            this.guidGenBtn.Size = new System.Drawing.Size(140, 30);
            this.guidGenBtn.TabIndex = 1;
            this.guidGenBtn.Text = "Сгенерировать новый";
            this.guidGenBtn.UseVisualStyleBackColor = true;
            this.guidGenBtn.Click += new System.EventHandler(this.GuidGenBtn_Click);
            // 
            // defGuidBtn
            // 
            this.defGuidBtn.Enabled = false;
            this.defGuidBtn.Location = new System.Drawing.Point(180, 136);
            this.defGuidBtn.Name = "defGuidBtn";
            this.defGuidBtn.Size = new System.Drawing.Size(140, 30);
            this.defGuidBtn.TabIndex = 2;
            this.defGuidBtn.Text = "Вернуть родной";
            this.defGuidBtn.UseVisualStyleBackColor = true;
            this.defGuidBtn.Click += new System.EventHandler(this.DefGuidBtn_Click);
            // 
            // name
            // 
            this.name.Enabled = false;
            this.name.Location = new System.Drawing.Point(20, 51);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(300, 20);
            this.name.TabIndex = 3;
            // 
            // openInWordBtn
            // 
            this.openInWordBtn.Enabled = false;
            this.openInWordBtn.Location = new System.Drawing.Point(20, 189);
            this.openInWordBtn.Name = "openInWordBtn";
            this.openInWordBtn.Size = new System.Drawing.Size(300, 40);
            this.openInWordBtn.TabIndex = 4;
            this.openInWordBtn.Text = "Открыть в Word";
            this.openInWordBtn.UseVisualStyleBackColor = true;
            this.openInWordBtn.Click += new System.EventHandler(this.OpenInWordBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Название отчета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "GUID";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(344, 24);
            this.menu.TabIndex = 7;
            this.menu.Text = "menuStrip1";
            // 
            // ToolStripMenu
            // 
            this.ToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFile,
            this.openFile,
            this.saveFile,
            this.saveAsFile,
            this.toolStripSeparator1,
            this.closeFile});
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenu.Text = "Фаил";
            // 
            // createFile
            // 
            this.createFile.Name = "createFile";
            this.createFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.createFile.Size = new System.Drawing.Size(164, 22);
            this.createFile.Text = "Создать";
            this.createFile.Click += new System.EventHandler(this.CreateFile_Click);
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFile.Size = new System.Drawing.Size(164, 22);
            this.openFile.Text = "Открыть";
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Enabled = false;
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(164, 22);
            this.saveFile.Text = "Сохранить";
            this.saveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // saveAsFile
            // 
            this.saveAsFile.Enabled = false;
            this.saveAsFile.Name = "saveAsFile";
            this.saveAsFile.Size = new System.Drawing.Size(164, 22);
            this.saveAsFile.Text = "Сохранить как";
            this.saveAsFile.Click += new System.EventHandler(this.SaveAsFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // closeFile
            // 
            this.closeFile.Enabled = false;
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(164, 22);
            this.closeFile.Text = "Закрыть";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(180, 22);
            this.about.Text = "О программе";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // guid
            // 
            this.guid.Enabled = false;
            this.guid.Location = new System.Drawing.Point(20, 110);
            this.guid.Name = "guid";
            this.guid.ReadOnly = true;
            this.guid.Size = new System.Drawing.Size(300, 20);
            this.guid.TabIndex = 8;
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleName = "save";
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(20, 251);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(300, 40);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Tag = "";
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 311);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.guid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openInWordBtn);
            this.Controls.Add(this.name);
            this.Controls.Add(this.defGuidBtn);
            this.Controls.Add(this.guidGenBtn);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование Word отчетов";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button guidGenBtn;
        private System.Windows.Forms.Button defGuidBtn;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button openInWordBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem createFile;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem saveAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeFile;
        private System.Windows.Forms.TextBox guid;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about;
    }
}

