namespace Library
{
    partial class ViewDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.addDayLabel = new System.Windows.Forms.Label();
            this.addMonthLabel = new System.Windows.Forms.Label();
            this.addCancelButton = new System.Windows.Forms.Button();
            this.addPublishLabel = new System.Windows.Forms.Label();
            this.addIsbnLabel = new System.Windows.Forms.Label();
            this.addALastLabel = new System.Windows.Forms.Label();
            this.addAFirstLabel = new System.Windows.Forms.Label();
            this.addTitleLabel = new System.Windows.Forms.Label();
            this.addDayTextBox = new System.Windows.Forms.TextBox();
            this.addYearTextBox = new System.Windows.Forms.TextBox();
            this.addMonthTextBox = new System.Windows.Forms.TextBox();
            this.addIsbnTextBox = new System.Windows.Forms.TextBox();
            this.addALastTextBox = new System.Windows.Forms.TextBox();
            this.addAFirstTextBox = new System.Windows.Forms.TextBox();
            this.addTitleTextBox = new System.Windows.Forms.TextBox();
            this.listCopies = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckedOutTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "YYYY";
            // 
            // addDayLabel
            // 
            this.addDayLabel.AutoSize = true;
            this.addDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDayLabel.Location = new System.Drawing.Point(143, 143);
            this.addDayLabel.Name = "addDayLabel";
            this.addDayLabel.Size = new System.Drawing.Size(23, 13);
            this.addDayLabel.TabIndex = 32;
            this.addDayLabel.Text = "DD";
            // 
            // addMonthLabel
            // 
            this.addMonthLabel.AutoSize = true;
            this.addMonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMonthLabel.Location = new System.Drawing.Point(102, 143);
            this.addMonthLabel.Name = "addMonthLabel";
            this.addMonthLabel.Size = new System.Drawing.Size(25, 13);
            this.addMonthLabel.TabIndex = 31;
            this.addMonthLabel.Text = "MM";
            // 
            // addCancelButton
            // 
            this.addCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCancelButton.Location = new System.Drawing.Point(187, 260);
            this.addCancelButton.Name = "addCancelButton";
            this.addCancelButton.Size = new System.Drawing.Size(75, 30);
            this.addCancelButton.TabIndex = 30;
            this.addCancelButton.Text = "Close";
            this.addCancelButton.UseVisualStyleBackColor = true;
            // 
            // addPublishLabel
            // 
            this.addPublishLabel.AutoSize = true;
            this.addPublishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPublishLabel.Location = new System.Drawing.Point(10, 124);
            this.addPublishLabel.Name = "addPublishLabel";
            this.addPublishLabel.Size = new System.Drawing.Size(84, 16);
            this.addPublishLabel.TabIndex = 28;
            this.addPublishLabel.Text = "Publish Date";
            // 
            // addIsbnLabel
            // 
            this.addIsbnLabel.AutoSize = true;
            this.addIsbnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addIsbnLabel.Location = new System.Drawing.Point(9, 96);
            this.addIsbnLabel.Name = "addIsbnLabel";
            this.addIsbnLabel.Size = new System.Drawing.Size(39, 16);
            this.addIsbnLabel.TabIndex = 27;
            this.addIsbnLabel.Text = "ISBN";
            // 
            // addALastLabel
            // 
            this.addALastLabel.AutoSize = true;
            this.addALastLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addALastLabel.Location = new System.Drawing.Point(9, 68);
            this.addALastLabel.Name = "addALastLabel";
            this.addALastLabel.Size = new System.Drawing.Size(74, 16);
            this.addALastLabel.TabIndex = 26;
            this.addALastLabel.Text = "Author Last";
            // 
            // addAFirstLabel
            // 
            this.addAFirstLabel.AutoSize = true;
            this.addAFirstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAFirstLabel.Location = new System.Drawing.Point(10, 42);
            this.addAFirstLabel.Name = "addAFirstLabel";
            this.addAFirstLabel.Size = new System.Drawing.Size(74, 16);
            this.addAFirstLabel.TabIndex = 25;
            this.addAFirstLabel.Text = "Author First";
            // 
            // addTitleLabel
            // 
            this.addTitleLabel.AutoSize = true;
            this.addTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTitleLabel.Location = new System.Drawing.Point(10, 16);
            this.addTitleLabel.Name = "addTitleLabel";
            this.addTitleLabel.Size = new System.Drawing.Size(34, 16);
            this.addTitleLabel.TabIndex = 24;
            this.addTitleLabel.Text = "Title";
            // 
            // addDayTextBox
            // 
            this.addDayTextBox.Enabled = false;
            this.addDayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDayTextBox.Location = new System.Drawing.Point(138, 121);
            this.addDayTextBox.Name = "addDayTextBox";
            this.addDayTextBox.Size = new System.Drawing.Size(32, 22);
            this.addDayTextBox.TabIndex = 22;
            this.addDayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // addYearTextBox
            // 
            this.addYearTextBox.Enabled = false;
            this.addYearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addYearTextBox.Location = new System.Drawing.Point(176, 121);
            this.addYearTextBox.Name = "addYearTextBox";
            this.addYearTextBox.Size = new System.Drawing.Size(38, 22);
            this.addYearTextBox.TabIndex = 23;
            this.addYearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // addMonthTextBox
            // 
            this.addMonthTextBox.Enabled = false;
            this.addMonthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMonthTextBox.Location = new System.Drawing.Point(100, 121);
            this.addMonthTextBox.Name = "addMonthTextBox";
            this.addMonthTextBox.Size = new System.Drawing.Size(32, 22);
            this.addMonthTextBox.TabIndex = 21;
            this.addMonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // addIsbnTextBox
            // 
            this.addIsbnTextBox.Enabled = false;
            this.addIsbnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addIsbnTextBox.Location = new System.Drawing.Point(100, 93);
            this.addIsbnTextBox.Name = "addIsbnTextBox";
            this.addIsbnTextBox.Size = new System.Drawing.Size(336, 22);
            this.addIsbnTextBox.TabIndex = 20;
            // 
            // addALastTextBox
            // 
            this.addALastTextBox.Enabled = false;
            this.addALastTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addALastTextBox.Location = new System.Drawing.Point(100, 65);
            this.addALastTextBox.Name = "addALastTextBox";
            this.addALastTextBox.Size = new System.Drawing.Size(336, 22);
            this.addALastTextBox.TabIndex = 19;
            // 
            // addAFirstTextBox
            // 
            this.addAFirstTextBox.Enabled = false;
            this.addAFirstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAFirstTextBox.Location = new System.Drawing.Point(100, 39);
            this.addAFirstTextBox.Name = "addAFirstTextBox";
            this.addAFirstTextBox.Size = new System.Drawing.Size(336, 22);
            this.addAFirstTextBox.TabIndex = 18;
            // 
            // addTitleTextBox
            // 
            this.addTitleTextBox.Enabled = false;
            this.addTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTitleTextBox.Location = new System.Drawing.Point(100, 13);
            this.addTitleTextBox.Name = "addTitleTextBox";
            this.addTitleTextBox.Size = new System.Drawing.Size(336, 22);
            this.addTitleTextBox.TabIndex = 17;
            // 
            // listCopies
            // 
            this.listCopies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.CheckedOutTo,
            this.Status});
            this.listCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCopies.FullRowSelect = true;
            this.listCopies.GridLines = true;
            this.listCopies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listCopies.HideSelection = false;
            this.listCopies.Location = new System.Drawing.Point(100, 159);
            this.listCopies.MultiSelect = false;
            this.listCopies.Name = "listCopies";
            this.listCopies.Size = new System.Drawing.Size(336, 97);
            this.listCopies.TabIndex = 36;
            this.listCopies.TabStop = false;
            this.listCopies.UseCompatibleStateImageBehavior = false;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 30;
            // 
            // CheckedOutTo
            // 
            this.CheckedOutTo.Text = "Checked out to...";
            this.CheckedOutTo.Width = 180;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 120;
            // 
            // ViewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 302);
            this.Controls.Add(this.listCopies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addDayLabel);
            this.Controls.Add(this.addMonthLabel);
            this.Controls.Add(this.addCancelButton);
            this.Controls.Add(this.addPublishLabel);
            this.Controls.Add(this.addIsbnLabel);
            this.Controls.Add(this.addALastLabel);
            this.Controls.Add(this.addAFirstLabel);
            this.Controls.Add(this.addTitleLabel);
            this.Controls.Add(this.addDayTextBox);
            this.Controls.Add(this.addYearTextBox);
            this.Controls.Add(this.addMonthTextBox);
            this.Controls.Add(this.addIsbnTextBox);
            this.Controls.Add(this.addALastTextBox);
            this.Controls.Add(this.addAFirstTextBox);
            this.Controls.Add(this.addTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title Details";
            this.Load += new System.EventHandler(this.ViewDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label addDayLabel;
        private System.Windows.Forms.Label addMonthLabel;
        private System.Windows.Forms.Button addCancelButton;
        private System.Windows.Forms.Label addPublishLabel;
        private System.Windows.Forms.Label addIsbnLabel;
        private System.Windows.Forms.Label addALastLabel;
        private System.Windows.Forms.Label addAFirstLabel;
        private System.Windows.Forms.Label addTitleLabel;
        private System.Windows.Forms.TextBox addDayTextBox;
        private System.Windows.Forms.TextBox addYearTextBox;
        private System.Windows.Forms.TextBox addMonthTextBox;
        private System.Windows.Forms.TextBox addIsbnTextBox;
        private System.Windows.Forms.TextBox addALastTextBox;
        private System.Windows.Forms.TextBox addAFirstTextBox;
        private System.Windows.Forms.TextBox addTitleTextBox;
        private System.Windows.Forms.ListView listCopies;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader CheckedOutTo;
        private System.Windows.Forms.ColumnHeader Status;
    }
}