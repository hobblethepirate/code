using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Library
{
    public partial class ViewDetails : Form
    {
        private Library _library;
        private List<LibraryBook> _books;

        public ViewDetails(ref List<LibraryBook> books, ref Library library)
        {
            InitializeComponent();
            _library = library;
            _books = books;
        }

        private void ViewDetails_Load(object sender, EventArgs e)
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
                listCopies.Items.Add(item);

            }

            listCopies.View = View.Details;

//            _library.LibraryList.
//            for (int i = 0; i < _books[0].; i++)
//            {
//                
//            }

        }

    }
}
