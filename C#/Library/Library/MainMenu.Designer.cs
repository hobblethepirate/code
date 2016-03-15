namespace Library
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookAddButton = new System.Windows.Forms.Button();
            this.bookRemoveButton = new System.Windows.Forms.Button();
            this.bookListView = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorFirst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ISBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookSearchTextBox = new System.Windows.Forms.TextBox();
            this.bookSearchButton = new System.Windows.Forms.Button();
            this.bookViewDetailButton = new System.Windows.Forms.Button();
            this.managerTab = new System.Windows.Forms.TabControl();
            this.bookManagerTab = new System.Windows.Forms.TabPage();
            this.bookEditButton = new System.Windows.Forms.Button();
            this.memberManagerTab = new System.Windows.Forms.TabPage();
            this.memberEditButton = new System.Windows.Forms.Button();
            this.memberRemoveButton = new System.Windows.Forms.Button();
            this.memberViewDetail = new System.Windows.Forms.Button();
            this.memberAddButton = new System.Windows.Forms.Button();
            this.memberListView = new System.Windows.Forms.ListView();
            this.memberFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberSearchButton = new System.Windows.Forms.Button();
            this.memberSearchTextBox = new System.Windows.Forms.TextBox();
            this.registerTab = new System.Windows.Forms.TabPage();
            this.registerCommitButton = new System.Windows.Forms.Button();
            this.reserveRadio = new System.Windows.Forms.RadioButton();
            this.checkInRadio = new System.Windows.Forms.RadioButton();
            this.checkOutRadio = new System.Windows.Forms.RadioButton();
            this.registerListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memberBox = new System.Windows.Forms.ComboBox();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.managerTab.SuspendLayout();
            this.bookManagerTab.SuspendLayout();
            this.memberManagerTab.SuspendLayout();
            this.registerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookAddButton
            // 
            this.bookAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookAddButton.Location = new System.Drawing.Point(520, 31);
            this.bookAddButton.Name = "bookAddButton";
            this.bookAddButton.Size = new System.Drawing.Size(75, 60);
            this.bookAddButton.TabIndex = 4;
            this.bookAddButton.Text = "Add";
            this.bookAddButton.UseVisualStyleBackColor = true;
            this.bookAddButton.Click += new System.EventHandler(this.bookAddButton_Click);
            // 
            // bookRemoveButton
            // 
            this.bookRemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookRemoveButton.Location = new System.Drawing.Point(520, 158);
            this.bookRemoveButton.Name = "bookRemoveButton";
            this.bookRemoveButton.Size = new System.Drawing.Size(75, 60);
            this.bookRemoveButton.TabIndex = 6;
            this.bookRemoveButton.Text = "Remove";
            this.bookRemoveButton.UseVisualStyleBackColor = true;
            this.bookRemoveButton.Click += new System.EventHandler(this.bookRemoveButton_Click);
            // 
            // bookListView
            // 
            this.bookListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.AuthorLast,
            this.AuthorFirst,
            this.ISBN});
            this.bookListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookListView.FullRowSelect = true;
            this.bookListView.GridLines = true;
            this.bookListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.bookListView.HideSelection = false;
            this.bookListView.Location = new System.Drawing.Point(7, 31);
            this.bookListView.MultiSelect = false;
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(498, 187);
            this.bookListView.TabIndex = 3;
            this.bookListView.TabStop = false;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            this.bookListView.SelectedIndexChanged += new System.EventHandler(this.bookListView_SelectedIndexChanged);
            this.bookListView.DoubleClick += new System.EventHandler(this.bookListView_DoubleClick);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 184;
            // 
            // AuthorLast
            // 
            this.AuthorLast.DisplayIndex = 2;
            this.AuthorLast.Text = "A. Last";
            this.AuthorLast.Width = 80;
            // 
            // AuthorFirst
            // 
            this.AuthorFirst.DisplayIndex = 1;
            this.AuthorFirst.Text = "A. First";
            this.AuthorFirst.Width = 80;
            // 
            // ISBN
            // 
            this.ISBN.Text = "ISBN";
            this.ISBN.Width = 150;
            // 
            // bookSearchTextBox
            // 
            this.bookSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookSearchTextBox.Location = new System.Drawing.Point(7, 4);
            this.bookSearchTextBox.Name = "bookSearchTextBox";
            this.bookSearchTextBox.Size = new System.Drawing.Size(219, 22);
            this.bookSearchTextBox.TabIndex = 1;
            // 
            // bookSearchButton
            // 
            this.bookSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookSearchButton.Location = new System.Drawing.Point(232, 3);
            this.bookSearchButton.Name = "bookSearchButton";
            this.bookSearchButton.Size = new System.Drawing.Size(61, 23);
            this.bookSearchButton.TabIndex = 2;
            this.bookSearchButton.Text = "Search";
            this.bookSearchButton.UseVisualStyleBackColor = true;
            this.bookSearchButton.Click += new System.EventHandler(this.bookSearchButton_Click);
            // 
            // bookViewDetailButton
            // 
            this.bookViewDetailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookViewDetailButton.Location = new System.Drawing.Point(232, 222);
            this.bookViewDetailButton.Name = "bookViewDetailButton";
            this.bookViewDetailButton.Size = new System.Drawing.Size(85, 23);
            this.bookViewDetailButton.TabIndex = 3;
            this.bookViewDetailButton.Text = "View Detail";
            this.bookViewDetailButton.UseVisualStyleBackColor = true;
            this.bookViewDetailButton.Click += new System.EventHandler(this.bookViewDetailButton_Click);
            // 
            // managerTab
            // 
            this.managerTab.Controls.Add(this.bookManagerTab);
            this.managerTab.Controls.Add(this.memberManagerTab);
            this.managerTab.Controls.Add(this.registerTab);
            this.managerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerTab.Font = new System.Drawing.Font("High Tower Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerTab.Location = new System.Drawing.Point(0, 0);
            this.managerTab.Multiline = true;
            this.managerTab.Name = "managerTab";
            this.managerTab.SelectedIndex = 0;
            this.managerTab.Size = new System.Drawing.Size(615, 284);
            this.managerTab.TabIndex = 1;
            this.managerTab.TabStop = false;
            // 
            // bookManagerTab
            // 
            this.bookManagerTab.BackColor = System.Drawing.SystemColors.Control;
            this.bookManagerTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bookManagerTab.Controls.Add(this.bookEditButton);
            this.bookManagerTab.Controls.Add(this.bookRemoveButton);
            this.bookManagerTab.Controls.Add(this.bookViewDetailButton);
            this.bookManagerTab.Controls.Add(this.bookAddButton);
            this.bookManagerTab.Controls.Add(this.bookListView);
            this.bookManagerTab.Controls.Add(this.bookSearchButton);
            this.bookManagerTab.Controls.Add(this.bookSearchTextBox);
            this.bookManagerTab.Location = new System.Drawing.Point(4, 28);
            this.bookManagerTab.Name = "bookManagerTab";
            this.bookManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.bookManagerTab.Size = new System.Drawing.Size(607, 252);
            this.bookManagerTab.TabIndex = 0;
            this.bookManagerTab.Text = "Book Manager";
            // 
            // bookEditButton
            // 
            this.bookEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEditButton.Location = new System.Drawing.Point(520, 94);
            this.bookEditButton.Name = "bookEditButton";
            this.bookEditButton.Size = new System.Drawing.Size(75, 60);
            this.bookEditButton.TabIndex = 5;
            this.bookEditButton.Text = "Edit";
            this.bookEditButton.UseVisualStyleBackColor = true;
            this.bookEditButton.Click += new System.EventHandler(this.bookEditButton_Click);
            // 
            // memberManagerTab
            // 
            this.memberManagerTab.BackColor = System.Drawing.SystemColors.Control;
            this.memberManagerTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.memberManagerTab.Controls.Add(this.memberEditButton);
            this.memberManagerTab.Controls.Add(this.memberRemoveButton);
            this.memberManagerTab.Controls.Add(this.memberViewDetail);
            this.memberManagerTab.Controls.Add(this.memberAddButton);
            this.memberManagerTab.Controls.Add(this.memberListView);
            this.memberManagerTab.Controls.Add(this.memberSearchButton);
            this.memberManagerTab.Controls.Add(this.memberSearchTextBox);
            this.memberManagerTab.Location = new System.Drawing.Point(4, 28);
            this.memberManagerTab.Name = "memberManagerTab";
            this.memberManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.memberManagerTab.Size = new System.Drawing.Size(607, 252);
            this.memberManagerTab.TabIndex = 1;
            this.memberManagerTab.Text = "Member Manager";
            // 
            // memberEditButton
            // 
            this.memberEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberEditButton.Location = new System.Drawing.Point(520, 94);
            this.memberEditButton.Name = "memberEditButton";
            this.memberEditButton.Size = new System.Drawing.Size(75, 60);
            this.memberEditButton.TabIndex = 4;
            this.memberEditButton.Text = "Edit";
            this.memberEditButton.UseVisualStyleBackColor = true;
            this.memberEditButton.Click += new System.EventHandler(this.memberEditButton_Click);
            // 
            // memberRemoveButton
            // 
            this.memberRemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberRemoveButton.Location = new System.Drawing.Point(520, 158);
            this.memberRemoveButton.Name = "memberRemoveButton";
            this.memberRemoveButton.Size = new System.Drawing.Size(75, 60);
            this.memberRemoveButton.TabIndex = 5;
            this.memberRemoveButton.Text = "Remove";
            this.memberRemoveButton.UseVisualStyleBackColor = true;
            this.memberRemoveButton.Click += new System.EventHandler(this.memberRemoveButton_Click);
            // 
            // memberViewDetail
            // 
            this.memberViewDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberViewDetail.Location = new System.Drawing.Point(232, 222);
            this.memberViewDetail.Name = "memberViewDetail";
            this.memberViewDetail.Size = new System.Drawing.Size(85, 23);
            this.memberViewDetail.TabIndex = 2;
            this.memberViewDetail.Text = "View Detail";
            this.memberViewDetail.UseVisualStyleBackColor = true;
            this.memberViewDetail.Click += new System.EventHandler(this.memberViewDetails);
            // 
            // memberAddButton
            // 
            this.memberAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberAddButton.Location = new System.Drawing.Point(520, 31);
            this.memberAddButton.Name = "memberAddButton";
            this.memberAddButton.Size = new System.Drawing.Size(75, 60);
            this.memberAddButton.TabIndex = 3;
            this.memberAddButton.Text = "Add";
            this.memberAddButton.UseVisualStyleBackColor = true;
            this.memberAddButton.Click += new System.EventHandler(this.memberAddButton_Click);
            // 
            // memberListView
            // 
            this.memberListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.memberFirstName,
            this.memberLastName,
            this.memberPhone,
            this.memberId});
            this.memberListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberListView.FullRowSelect = true;
            this.memberListView.GridLines = true;
            this.memberListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.memberListView.HideSelection = false;
            this.memberListView.Location = new System.Drawing.Point(7, 31);
            this.memberListView.MultiSelect = false;
            this.memberListView.Name = "memberListView";
            this.memberListView.Size = new System.Drawing.Size(498, 187);
            this.memberListView.TabIndex = 9;
            this.memberListView.TabStop = false;
            this.memberListView.UseCompatibleStateImageBehavior = false;
            this.memberListView.DoubleClick += new System.EventHandler(this.memberListView_DoubleClick);
            // 
            // memberFirstName
            // 
            this.memberFirstName.Text = "First";
            this.memberFirstName.Width = 100;
            // 
            // memberLastName
            // 
            this.memberLastName.Text = "Last";
            this.memberLastName.Width = 100;
            // 
            // memberPhone
            // 
            this.memberPhone.Text = "Phone";
            this.memberPhone.Width = 100;
            // 
            // memberId
            // 
            this.memberId.Text = "Member ID";
            this.memberId.Width = 100;
            // 
            // memberSearchButton
            // 
            this.memberSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberSearchButton.Location = new System.Drawing.Point(232, 3);
            this.memberSearchButton.Name = "memberSearchButton";
            this.memberSearchButton.Size = new System.Drawing.Size(61, 23);
            this.memberSearchButton.TabIndex = 1;
            this.memberSearchButton.Text = "Search";
            this.memberSearchButton.UseVisualStyleBackColor = true;
            this.memberSearchButton.Click += new System.EventHandler(this.memberSearchButton_Click);
            // 
            // memberSearchTextBox
            // 
            this.memberSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberSearchTextBox.Location = new System.Drawing.Point(7, 4);
            this.memberSearchTextBox.Name = "memberSearchTextBox";
            this.memberSearchTextBox.Size = new System.Drawing.Size(219, 22);
            this.memberSearchTextBox.TabIndex = 0;
            // 
            // registerTab
            // 
            this.registerTab.BackColor = System.Drawing.SystemColors.Control;
            this.registerTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.registerTab.Controls.Add(this.registerCommitButton);
            this.registerTab.Controls.Add(this.reserveRadio);
            this.registerTab.Controls.Add(this.checkInRadio);
            this.registerTab.Controls.Add(this.checkOutRadio);
            this.registerTab.Controls.Add(this.registerListView);
            this.registerTab.Controls.Add(this.memberBox);
            this.registerTab.Location = new System.Drawing.Point(4, 28);
            this.registerTab.Name = "registerTab";
            this.registerTab.Size = new System.Drawing.Size(607, 252);
            this.registerTab.TabIndex = 2;
            this.registerTab.Text = "Register";
            // 
            // registerCommitButton
            // 
            this.registerCommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerCommitButton.Location = new System.Drawing.Point(512, 219);
            this.registerCommitButton.Name = "registerCommitButton";
            this.registerCommitButton.Size = new System.Drawing.Size(85, 28);
            this.registerCommitButton.TabIndex = 5;
            this.registerCommitButton.Text = "Commit";
            this.registerCommitButton.UseVisualStyleBackColor = true;
            this.registerCommitButton.Click += new System.EventHandler(this.registerCommitButton_Click);
            // 
            // reserveRadio
            // 
            this.reserveRadio.AutoSize = true;
            this.reserveRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserveRadio.Location = new System.Drawing.Point(6, 139);
            this.reserveRadio.Name = "reserveRadio";
            this.reserveRadio.Size = new System.Drawing.Size(79, 21);
            this.reserveRadio.TabIndex = 4;
            this.reserveRadio.Text = "Reserve";
            this.reserveRadio.UseVisualStyleBackColor = true;
            this.reserveRadio.CheckedChanged += new System.EventHandler(this.reserveRadio_CheckedChanged);
            // 
            // checkInRadio
            // 
            this.checkInRadio.AutoSize = true;
            this.checkInRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInRadio.Location = new System.Drawing.Point(6, 110);
            this.checkInRadio.Name = "checkInRadio";
            this.checkInRadio.Size = new System.Drawing.Size(80, 21);
            this.checkInRadio.TabIndex = 3;
            this.checkInRadio.Text = "Check In";
            this.checkInRadio.UseVisualStyleBackColor = true;
            this.checkInRadio.CheckedChanged += new System.EventHandler(this.checkInRadio_CheckedChanged);
            // 
            // checkOutRadio
            // 
            this.checkOutRadio.AutoSize = true;
            this.checkOutRadio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkOutRadio.Checked = true;
            this.checkOutRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutRadio.Location = new System.Drawing.Point(6, 81);
            this.checkOutRadio.Name = "checkOutRadio";
            this.checkOutRadio.Size = new System.Drawing.Size(92, 21);
            this.checkOutRadio.TabIndex = 2;
            this.checkOutRadio.TabStop = true;
            this.checkOutRadio.Text = "Check Out";
            this.checkOutRadio.UseVisualStyleBackColor = false;
            this.checkOutRadio.CheckedChanged += new System.EventHandler(this.checkOutRadio_CheckedChanged);
            // 
            // registerListView
            // 
            this.registerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.registerListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.registerListView.FullRowSelect = true;
            this.registerListView.GridLines = true;
            this.registerListView.Location = new System.Drawing.Point(104, 37);
            this.registerListView.Name = "registerListView";
            this.registerListView.Size = new System.Drawing.Size(493, 176);
            this.registerListView.TabIndex = 1;
            this.registerListView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 184;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "A. Last";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "A. First";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ISBN";
            this.columnHeader4.Width = 127;
            // 
            // memberBox
            // 
            this.memberBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memberBox.Location = new System.Drawing.Point(7, 4);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(219, 27);
            this.memberBox.TabIndex = 0;
            this.memberBox.SelectedIndexChanged += new System.EventHandler(this.memberBox_SelectedIndexChanged);
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Location = new System.Drawing.Point(540, 5);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(66, 13);
            this.teamNameLabel.TabIndex = 9;
            this.teamNameLabel.Text = "Green Team";
            // 
            // MainMenu
            // 
            this.AcceptButton = this.bookSearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 284);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.managerTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CST236 Library Manager 2013";
            this.managerTab.ResumeLayout(false);
            this.bookManagerTab.ResumeLayout(false);
            this.bookManagerTab.PerformLayout();
            this.memberManagerTab.ResumeLayout(false);
            this.memberManagerTab.PerformLayout();
            this.registerTab.ResumeLayout(false);
            this.registerTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bookAddButton;
        private System.Windows.Forms.Button bookRemoveButton;
        private System.Windows.Forms.ListView bookListView;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader AuthorFirst;
        private System.Windows.Forms.ColumnHeader AuthorLast;
        private System.Windows.Forms.ColumnHeader ISBN;
        private System.Windows.Forms.TextBox bookSearchTextBox;
        private System.Windows.Forms.Button bookSearchButton;
        private System.Windows.Forms.Button bookViewDetailButton;
        private System.Windows.Forms.TabControl managerTab;
        private System.Windows.Forms.TabPage bookManagerTab;
        private System.Windows.Forms.TabPage memberManagerTab;
        private System.Windows.Forms.Button memberRemoveButton;
        private System.Windows.Forms.Button memberViewDetail;
        private System.Windows.Forms.Button memberAddButton;
        private System.Windows.Forms.ListView memberListView;
        private System.Windows.Forms.ColumnHeader memberFirstName;
        private System.Windows.Forms.ColumnHeader memberLastName;
        private System.Windows.Forms.Button memberSearchButton;
        private System.Windows.Forms.TextBox memberSearchTextBox;
        private System.Windows.Forms.TabPage registerTab;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Button bookEditButton;
        private System.Windows.Forms.ColumnHeader memberPhone;
        private System.Windows.Forms.ColumnHeader memberId;
        private System.Windows.Forms.Button memberEditButton;
        private System.Windows.Forms.ComboBox memberBox;
        private System.Windows.Forms.ListView registerListView;
        private System.Windows.Forms.RadioButton checkOutRadio;
        private System.Windows.Forms.RadioButton reserveRadio;
        private System.Windows.Forms.RadioButton checkInRadio;
        private System.Windows.Forms.Button registerCommitButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

