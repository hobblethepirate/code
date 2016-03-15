using System;
using System.Windows.Forms;

namespace Library
{
    public partial class AddMember : Form
    {
        private readonly MembershipList _membershipList;

        public AddMember(ref MembershipList membershipList)
        {
            InitializeComponent();
            _membershipList = membershipList;
        }

        private void addCommitButton_Click(object sender, EventArgs e)
        {
            try
            {
                int results = _membershipList.AddMember(addMemberFirstTextBox.Text,
                                                       addMemberLastTextBox.Text,
                                                       addMemberAddress1TextBox.Text,
                                                       addMemberAddress2TextBox.Text,
                                                       addMemberCityTextBox.Text,
                                                       addMemberStateTextBox.Text,
                                                       addMemberZipTextBox.Text,
                                                       addMemberPhoneTextBox.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Member successfully added");
            this.Close();
                
            }
        }
    }

