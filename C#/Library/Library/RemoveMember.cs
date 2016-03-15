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
    public partial class RemoveMember : Form
    {
        private MembershipList members;
        private Library lib;
        private long idm;

        public RemoveMember(ref long id, ref MembershipList memberList, ref Library library)
        {

            InitializeComponent();
            idm = id;
            members = memberList;
            lib = library;
            Member selected = members.FindById(id);
            RemoveMemberDetails.Text = selected.FirstName + " " + selected.Lastname + "\r\n"
                        + selected.AddressLine1 + " " + selected.AddressLine2 + "\r\n"
                        + selected.City + ", " + selected.State + " " + selected.ZipCode + "\r\n" + selected.PhoneNumber.ToString();
            this.Text = "Removing "+ selected.FirstName + " " + selected.Lastname;          
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Member temp = members.FindById(idm);
            foreach (MemberBook a in temp.MemberBooks)
            {
                lib.ResetById(a.BookId);
            }
            Boolean results = members.RemoveMember(idm);

            if (results == false)
            {
                MessageBox.Show("Unable to Remove Member, id doesn't exist");
            }
            else
            {
                MessageBox.Show("Member Successfully Removed!");
            }
            this.Close();
        }

        private void RemoveCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
