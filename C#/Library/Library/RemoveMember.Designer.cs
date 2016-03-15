namespace Library
{
    partial class RemoveMember
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
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RemoveCancelButton = new System.Windows.Forms.Button();
            this.RemoveMemberDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(333, 171);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(71, 25);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RemoveCancelButton
            // 
            this.RemoveCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveCancelButton.Location = new System.Drawing.Point(12, 171);
            this.RemoveCancelButton.Name = "RemoveCancelButton";
            this.RemoveCancelButton.Size = new System.Drawing.Size(71, 25);
            this.RemoveCancelButton.TabIndex = 1;
            this.RemoveCancelButton.Text = "Cancel";
            this.RemoveCancelButton.UseVisualStyleBackColor = true;
            this.RemoveCancelButton.Click += new System.EventHandler(this.RemoveCancelButton_Click);
            // 
            // RemoveMemberDetails
            // 
            this.RemoveMemberDetails.Enabled = false;
            this.RemoveMemberDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveMemberDetails.Location = new System.Drawing.Point(12, 38);
            this.RemoveMemberDetails.Multiline = true;
            this.RemoveMemberDetails.Name = "RemoveMemberDetails";
            this.RemoveMemberDetails.Size = new System.Drawing.Size(392, 127);
            this.RemoveMemberDetails.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Are you sure you want to remove this member?";
            // 
            // RemoveMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 203);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemoveMemberDetails);
            this.Controls.Add(this.RemoveCancelButton);
            this.Controls.Add(this.RemoveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button RemoveCancelButton;
        private System.Windows.Forms.TextBox RemoveMemberDetails;
        private System.Windows.Forms.Label label1;
    }
}