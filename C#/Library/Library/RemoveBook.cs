using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Library
{
    public partial class RemoveBook : Form
    {
        private Library _library;
        private List<LibraryBook> _books;

        public RemoveBook(ref List<LibraryBook> books, ref Library library)
        {
            InitializeComponent();
            _library = library;
            _books = books;
        }

        private void RemoveBook_Load(object sender, EventArgs e)
        {
            //Populate the fields on the form

            this.addTitleTextBox.Text = _books[0].Title;
            this.addALastTextBox.Text = _books[0].AuthorLastName;
            this.addAFirstTextBox.Text = _books[0].AuthorFirstName;
            this.addIsbnTextBox.Text = _books[0].Isbn.ToString();
            this.addDayTextBox.Text = _books[0].PublishingDate.Day.ToString();
            this.addMonthTextBox.Text = _books[0].PublishingDate.Month.ToString();
            this.addYearTextBox.Text = _books[0].PublishingDate.Year.ToString();

            for (int i = 0; i < _books[0].BookIdent.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = _books[0].BookIdent[i].BookId.ToString();
                item.SubItems.Add(_books[0].BookIdent[i].Owner.Lastname);
                item.SubItems.Add(_books[0].BookIdent[i].Status.ToString());
                removeBookListView.Items.Add(item);

            }

            removeBookListView.View = View.Details;

        }

        private void removeBookButton_Click(object sender, EventArgs e)
        {
            if (!(removeBookListView.SelectedItems.Count != 0))
            {
                MessageBox.Show("Please select a copy to remove.");
            }
            else
            {
                // Get the library book 
                // Select all copies of books that match the ISBN
                // Get the ISBN from the selected book
                ListViewItem item = removeBookListView.FocusedItem;

                if (_library.RemoveBook(_books, long.Parse(item.SubItems[0].Text)))
                {
                    MessageBox.Show("Book successfully removed!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error removing book.");
                }
            }
        }

    }
}
