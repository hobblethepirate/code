namespace Library
{
    partial class EditBook
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
            this.editCommitButton = new System.Windows.Forms.Button();
            this.addPublishLabel = new System.Windows.Forms.Label();
            this.addIsbnLabel = new System.Windows.Forms.Label();
            this.addALastLabel = new System.Windows.Forms.Label();
            this.addAFirstLabel = new System.Windows.Forms.Label();
            this.addTitleLabel = new System.Windows.Forms.Label();
            this.editDayTextBox = new System.Windows.Forms.TextBox();
            this.editYearTextBox = new System.Windows.Forms.TextBox();
            this.editMonthTextBox = new System.Windows.Forms.TextBox();
            this.editIsbnTextBox = new System.Windows.Forms.TextBox();
            this.editALastTextBox = new System.Windows.Forms.TextBox();
            this.editAFirstTextBox = new System.Windows.Forms.TextBox();
            this.editTitleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "YYYY";
            // 
            // addDayLabel
            // 
            this.addDayLabel.AutoSize = true;
            this.addDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDayLabel.Location = new System.Drawing.Point(141, 136);
            this.addDayLabel.Name = "addDayLabel";
            this.addDayLabel.Size = new System.Drawing.Size(23, 13);
            this.addDayLabel.TabIndex = 32;
            this.addDayLabel.Text = "DD";
            // 
            // addMonthLabel
            // 
            this.addMonthLabel.AutoSize = true;
            this.addMonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMonthLabel.Location = new System.Drawing.Point(100, 136);
            this.addMonthLabel.Name = "addMonthLabel";
            this.addMonthLabel.Size = new System.Drawing.Size(25, 13);
            this.addMonthLabel.TabIndex = 31;
            this.addMonthLabel.Text = "MM";
            // 
            // addCancelButton
            // 
            this.addCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.addCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCancelButton.Location = new System.Drawing.Point(11, 173);
            this.addCancelButton.Name = "addCancelButton";
            this.addCancelButton.Size = new System.Drawing.Size(75, 30);
            this.addCancelButton.TabIndex = 30;
            this.addCancelButton.Text = "Cancel";
            this.addCancelButton.UseVisualStyleBackColor = true;
            // 
            // editCommitButton
            // 
            this.editCommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCommitButton.Location = new System.Drawing.Point(195, 173);
            this.editCommitButton.Name = "editCommitButton";
            this.editCommitButton.Size = new System.Drawing.Size(75, 30);
            this.editCommitButton.TabIndex = 29;
            this.editCommitButton.Text = "Commit";
            this.editCommitButton.UseVisualStyleBackColor = true;
            this.editCommitButton.Click += new System.EventHandler(this.addCommitButton_Click);
            // 
            // addPublishLabel
            // 
            this.addPublishLabel.AutoSize = true;
            this.addPublishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPublishLabel.Location = new System.Drawing.Point(8, 117);
            this.addPublishLabel.Name = "addPublishLabel";
            this.addPublishLabel.Size = new System.Drawing.Size(84, 16);
            this.addPublishLabel.TabIndex = 28;
            this.addPublishLabel.Text = "Publish Date";
            // 
            // addIsbnLabel
            // 
            this.addIsbnLabel.AutoSize = true;
            this.addIsbnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addIsbnLabel.Location = new System.Drawing.Point(7, 89);
            this.addIsbnLabel.Name = "addIsbnLabel";
            this.addIsbnLabel.Size = new System.Drawing.Size(39, 16);
            this.addIsbnLabel.TabIndex = 27;
            this.addIsbnLabel.Text = "ISBN";
            // 
            // addALastLabel
            // 
            this.addALastLabel.AutoSize = true;
            this.addALastLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addALastLabel.Location = new System.Drawing.Point(7, 61);
            this.addALastLabel.Name = "addALastLabel";
            this.addALastLabel.Size = new System.Drawing.Size(74, 16);
            this.addALastLabel.TabIndex = 26;
            this.addALastLabel.Text = "Author Last";
            // 
            // addAFirstLabel
            // 
            this.addAFirstLabel.AutoSize = true;
            this.addAFirstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAFirstLabel.Location = new System.Drawing.Point(8, 35);
            this.addAFirstLabel.Name = "addAFirstLabel";
            this.addAFirstLabel.Size = new System.Drawing.Size(74, 16);
            this.addAFirstLabel.TabIndex = 25;
            this.addAFirstLabel.Text = "Author First";
            // 
            // addTitleLabel
            // 
            this.addTitleLabel.AutoSize = true;
            this.addTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTitleLabel.Location = new System.Drawing.Point(8, 9);
            this.addTitleLabel.Name = "addTitleLabel";
            this.addTitleLabel.Size = new System.Drawing.Size(34, 16);
            this.addTitleLabel.TabIndex = 24;
            this.addTitleLabel.Text = "Title";
            // 
            // editDayTextBox
            // 
            this.editDayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDayTextBox.Location = new System.Drawing.Point(136, 114);
            this.editDayTextBox.MaxLength = 2;
            this.editDayTextBox.Name = "editDayTextBox";
            this.editDayTextBox.Size = new System.Drawing.Size(32, 22);
            this.editDayTextBox.TabIndex = 22;
            // 
            // editYearTextBox
            // 
            this.editYearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editYearTextBox.Location = new System.Drawing.Point(174, 114);
            this.editYearTextBox.MaxLength = 4;
            this.editYearTextBox.Name = "editYearTextBox";
            this.editYearTextBox.Size = new System.Drawing.Size(38, 22);
            this.editYearTextBox.TabIndex = 23;
            // 
            // editMonthTextBox
            // 
            this.editMonthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editMonthTextBox.Location = new System.Drawing.Point(98, 114);
            this.editMonthTextBox.MaxLength = 2;
            this.editMonthTextBox.Name = "editMonthTextBox";
            this.editMonthTextBox.Size = new System.Drawing.Size(32, 22);
            this.editMonthTextBox.TabIndex = 21;
            // 
            // editIsbnTextBox
            // 
            this.editIsbnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editIsbnTextBox.Location = new System.Drawing.Point(98, 86);
            this.editIsbnTextBox.MaxLength = 13;
            this.editIsbnTextBox.Name = "editIsbnTextBox";
            this.editIsbnTextBox.Size = new System.Drawing.Size(113, 22);
            this.editIsbnTextBox.TabIndex = 20;
            // 
            // editALastTextBox
            // 
            this.editALastTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editALastTextBox.Location = new System.Drawing.Point(98, 58);
            this.editALastTextBox.Name = "editALastTextBox";
            this.editALastTextBox.Size = new System.Drawing.Size(172, 22);
            this.editALastTextBox.TabIndex = 19;
            // 
            // editAFirstTextBox
            // 
            this.editAFirstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAFirstTextBox.Location = new System.Drawing.Point(98, 32);
            this.editAFirstTextBox.Name = "editAFirstTextBox";
            this.editAFirstTextBox.Size = new System.Drawing.Size(172, 22);
            this.editAFirstTextBox.TabIndex = 18;
            // 
            // editTitleTextBox
            // 
            this.editTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTitleTextBox.Location = new System.Drawing.Point(98, 6);
            this.editTitleTextBox.Name = "editTitleTextBox";
            this.editTitleTextBox.Size = new System.Drawing.Size(172, 22);
            this.editTitleTextBox.TabIndex = 17;
            // 
            // EditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 216);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addDayLabel);
            this.Controls.Add(this.addMonthLabel);
            this.Controls.Add(this.addCancelButton);
            this.Controls.Add(this.editCommitButton);
            this.Controls.Add(this.addPublishLabel);
            this.Controls.Add(this.addIsbnLabel);
            this.Controls.Add(this.addALastLabel);
            this.Controls.Add(this.addAFirstLabel);
            this.Controls.Add(this.addTitleLabel);
            this.Controls.Add(this.editDayTextBox);
            this.Controls.Add(this.editYearTextBox);
            this.Controls.Add(this.editMonthTextBox);
            this.Controls.Add(this.editIsbnTextBox);
            this.Controls.Add(this.editALastTextBox);
            this.Controls.Add(this.editAFirstTextBox);
            this.Controls.Add(this.editTitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label addDayLabel;
        private System.Windows.Forms.Label addMonthLabel;
        private System.Windows.Forms.Button addCancelButton;
        private System.Windows.Forms.Button editCommitButton;
        private System.Windows.Forms.Label addPublishLabel;
        private System.Windows.Forms.Label addIsbnLabel;
        private System.Windows.Forms.Label addALastLabel;
        private System.Windows.Forms.Label addAFirstLabel;
        private System.Windows.Forms.Label addTitleLabel;
        private System.Windows.Forms.TextBox editDayTextBox;
        private System.Windows.Forms.TextBox editYearTextBox;
        private System.Windows.Forms.TextBox editMonthTextBox;
        private System.Windows.Forms.TextBox editIsbnTextBox;
        private System.Windows.Forms.TextBox editALastTextBox;
        private System.Windows.Forms.TextBox editAFirstTextBox;
        private System.Windows.Forms.TextBox editTitleTextBox;

        public System.EventHandler Form1_Load { get; set; }
    }
}