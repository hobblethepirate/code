using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class EditMember : Form
    {
        private MembershipList members;
        private long idm;
        private Member result;

        public EditMember(ref long id, ref MembershipList memberList)
        {
            InitializeComponent();

            members = memberList;
            idm = id;
            
            result = members.FindById(id);
            this.Text = "Editing " + result.FirstName + " " + result.Lastname;
            editMemberFirstTextBox.Text = result.FirstName;
            editMemberLastTextBox.Text = result.Lastname;
            editMemberAddress1TextBox.Text = result.AddressLine1;
            editMemberAddress2TextBox.Text = result.AddressLine2;
            editMemberCityTextBox.Text = result.City;
            editMemberStateTextBox.Text = result.State;
            editMemberZipTextBox.Text = result.ZipCode.ToString();
            editMemberPhoneTextBox.Text = result.PhoneNumber.ToString();
        }

        private void editCommitButton_Click(object sender, EventArgs e)
        {
            if (editMemberFirstTextBox.Text != result.FirstName || editMemberLastTextBox.Text != result.Lastname ||
            editMemberAddress1TextBox.Text != result.AddressLine1 || editMemberAddress2TextBox.Text != result.AddressLine2 ||
            editMemberCityTextBox.Text != result.City || editMemberStateTextBox.Text != result.State ||
            editMemberZipTextBox.Text != result.ZipCode.ToString() || editMemberPhoneTextBox.Text != result.PhoneNumber.ToString())
            {
                try
                {
                    int info = members.EditMember(editMemberFirstTextBox.Text, editMemberLastTextBox.Text, editMemberAddress1TextBox.Text,
                        editMemberAddress2TextBox.Text, editMemberCityTextBox.Text, editMemberStateTextBox.Text, editMemberZipTextBox.Text, editMemberPhoneTextBox.Text, idm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                 MessageBox.Show("Member Successfully Edited!");
                 this.Close();
            }
        }

        private void editCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
