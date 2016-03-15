using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Library
{
    public partial class ViewMemberDetails : Form
    {
        private Library _library;
        private Member _member;
        private ListView _checkedOutList;
        private ListView _reservedList;

        public ViewMemberDetails(ref Member member, ref Library library, ref ListView checkedOutList, ref ListView reservedList )
        {
            InitializeComponent();
            _library = library;
            _member = member;
            _checkedOutList = checkedOutList;
            _reservedList = reservedList;
        }

        private void ViewMemberDetails_Load(object sender, EventArgs e)
        {
            this.viewMemberFirstTextBox.Text = _member.FirstName;
            this.viewMemberLastTextBox.Text = _member.Lastname;
            this.viewMemberAddress1TextBox.Text = _member.AddressLine1;
            this.viewMemberAddress2TextBox.Text = _member.AddressLine2;
            this.viewMemberCityTextBox.Text = _member.City;
            this.viewMemberStateTextBox.Text = _member.State;
            this.viewMemberZipTextBox.Text = _member.ZipCode.ToString();
            this.viewMemberPhoneTextBox.Text = _member.PhoneNumber.ToString();

            checkedOutList.View = View.Details;
            reservedList.View = View.Details;

            foreach (ListViewItem item in _checkedOutList.Items)
            {
                this.checkedOutList.Items.Add((ListViewItem)item.Clone());
            }

            foreach (ListViewItem item in _reservedList.Items)
            {
                this.reservedList.Items.Add((ListViewItem)item.Clone());
            }
            

        }

 
    }
}
