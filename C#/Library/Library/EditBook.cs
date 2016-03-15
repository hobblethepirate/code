using System;
using System.Windows.Forms;

namespace Library
{
    public partial class EditBook : Form
    {
        private Library current;
        private int pos;

        public EditBook(ref int position, ref Library library)
        {
            InitializeComponent();
            
            current = library;
            pos=position;
            editTitleTextBox.Text = current.LibraryList[pos].Title;
            editAFirstTextBox.Text = current.LibraryList[pos].AuthorFirstName;
            editALastTextBox.Text = current.LibraryList[pos].AuthorLastName;
            editIsbnTextBox.Text = current.LibraryList[pos].Isbn.ToString();
            editDayTextBox.Text = current.LibraryList[pos].PublishingDate.Day.ToString();
            editMonthTextBox.Text = current.LibraryList[pos].PublishingDate.Month.ToString();
            editYearTextBox.Text = current.LibraryList[pos].PublishingDate.Year.ToString();         
        }

        private void addCommitButton_Click(object sender, EventArgs e)
        {
            //making sure we are submitting a change
            if (editTitleTextBox.Text != current.LibraryList[pos].Title || editAFirstTextBox.Text != current.LibraryList[pos].AuthorFirstName ||
            editALastTextBox.Text != current.LibraryList[pos].AuthorLastName || editIsbnTextBox.Text != current.LibraryList[pos].Isbn.ToString() ||
            editDayTextBox.Text != current.LibraryList[pos].PublishingDate.Day.ToString() || editMonthTextBox.Text != current.LibraryList[pos].PublishingDate.Month.ToString() ||
            editYearTextBox.Text != current.LibraryList[pos].PublishingDate.Year.ToString())
            {
                int results = current.EditBook(editTitleTextBox.Text, editAFirstTextBox.Text, editALastTextBox.Text,
                                 editIsbnTextBox.Text, editMonthTextBox.Text, editDayTextBox.Text, editYearTextBox.Text, pos);
                switch (results)
                {
                    case 0:
                        MessageBox.Show("Book Successfully Edited!.");
                        break;
                    case 1:
                        MessageBox.Show("Please enter a Title.");
                        return;
                    case 2:
                        MessageBox.Show("Please enter a valid first name.");
                        return;
                    case 3:
                        MessageBox.Show("Please enter a valid last name.");
                        return;
                    case 4:
                        MessageBox.Show("Please enter a valid ISBN-13");
                        return;
                    case 5:
                        MessageBox.Show("Please enter a valid date. (mm/dd/yyyy)");
                        return;
                }
                this.Close();
                 
            }   
        }
    }
}
