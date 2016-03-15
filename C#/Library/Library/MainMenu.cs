using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Library
{
    public partial class MainMenu : Form
    {

        private Library _library;
        private MembershipList _membershipList;
        private Register _register;

        public MainMenu()
        {

            InitializeComponent();
            _library = new Library();
            _membershipList = new MembershipList();
            _register = new Register(ref _library, ref _membershipList);
            InitializeListView();

        }

        private void InitializeListView()
        {
            bookListView.Items.Clear();
            foreach (LibraryBook libraryBook in _library.LibraryList)
            {
                ListViewItem item = new ListViewItem();
                item.Text = libraryBook.Title;
                item.SubItems.Add(libraryBook.AuthorLastName);
                item.SubItems.Add(libraryBook.AuthorFirstName);
                item.SubItems.Add(libraryBook.Isbn.ToString(CultureInfo.InvariantCulture));
                bookListView.Items.Add(item);
            }
           
            bookListView.View = View.Details;

            memberListView.Items.Clear();
            memberBox.Items.Clear();
            foreach (Member member in _membershipList.MemberList)
            {
                ListViewItem item = new ListViewItem();
                item.Text = member.FirstName;
                item.SubItems.Add(member.Lastname);
                item.SubItems.Add(member.PhoneNumber.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(member.MemberId.ToString(CultureInfo.InvariantCulture));
                memberListView.Items.Add(item);

                memberBox.Items.Add(member);
            }
            memberBox.SelectedIndex = 0;
            memberListView.View = View.Details;

            EventArgs e = new EventArgs();
            if (checkOutRadio.Checked == true)
            {

                checkOutRadio_CheckedChanged(this,e);
            }
            
            else if (checkInRadio.Checked == true)
            {

                checkInRadio_CheckedChanged(this, e);
            
            }
            else
            {
                reserveRadio_CheckedChanged(this, e);
            }
        }

        private void bookAddButton_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook(ref _library);

            addBook.ShowDialog();
            bookSearchButton_Click(sender, e);
        }

        private void bookRemoveButton_Click(object sender, EventArgs e)
        {
            if ((bookListView.SelectedItems.Count == 0))
            {
                MessageBox.Show("Please select a book to remove.");
            }
            else
            {
                // Get the library book 
                // Select all copies of books that match the ISBN
                // Get the ISBN from the selected book
                ListViewItem item = bookListView.FocusedItem;
                long _isbn;
                _isbn = long.Parse(item.SubItems[3].Text.ToString());

                // Find all books that match the ISBN
                List<LibraryBook> books = _library.Search(_isbn.ToString());

                RemoveBook removeBook = new RemoveBook(ref books, ref _library);
                removeBook.ShowDialog();
            }
            bookSearchButton_Click(sender, e);
        }

        private void bookListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bookSearchButton_Click(object sender, EventArgs e)
        {
            //Send the user's input
            List<LibraryBook> results = _library.Search(bookSearchTextBox.Text);

            //Clear exsiting list and display
            bookListView.Items.Clear();
            foreach (LibraryBook libraryBook in results)
            {
                ListViewItem item = new ListViewItem();
                item.Text = libraryBook.Title;
                item.SubItems.Add(libraryBook.AuthorLastName);
                item.SubItems.Add(libraryBook.AuthorFirstName);
                item.SubItems.Add(libraryBook.Isbn.ToString(CultureInfo.InvariantCulture));
                bookListView.Items.Add(item);
            }
            
        }

        private void bookViewDetailButton_Click(object sender, EventArgs e)
        {
            if (!(bookListView.SelectedItems.Count != 0))
            {
                MessageBox.Show("Please select a book to view.");
            }
            else
            {
                // Get the library book 
                // Select all copies of books that match teh ISBN
                // Get the ISBN from the selected book
                ListViewItem item = bookListView.FocusedItem;
                long _isbn;
                _isbn = long.Parse(item.SubItems[3].Text);

                // Find all books that match the ISBN
                List<LibraryBook> books = _library.Search(_isbn.ToString());

                ViewDetails viewDetails = new ViewDetails(ref books, ref _library);
                viewDetails.ShowDialog();
                                
            }
        }

        private void bookListView_DoubleClick(object sender, EventArgs e)
        {
            bookViewDetailButton_Click(sender, e);
        }

        private void bookEditButton_Click(object sender, EventArgs e)
        {
            if (bookListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a book to edit.");
            }
            else
            {
                long _isbn;
                _isbn = long.Parse(bookListView.FocusedItem.SubItems[3].Text);
                List<LibraryBook> books = _library.Search(_isbn.ToString());
                LibraryBook book = books[0];
                int pos =_library.LibraryList.IndexOf(book);
                EditBook editbook = new EditBook(ref pos, ref _library);
                editbook.ShowDialog();
                bookSearchButton_Click(sender, e);
            }
        }

        private void memberAddButton_Click(object sender, EventArgs e)
        {

            AddMember addMember = new AddMember(ref _membershipList);
            addMember.ShowDialog();
            memberSearchButton_Click(sender, e);
            InitializeListView();
        }

        private void memberRemoveButton_Click(object sender, EventArgs e)
        {
            if (memberListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a member to remove.");
            }
            else
            {
                long id = long.Parse(memberListView.FocusedItem.SubItems[3].Text);
                RemoveMember removeMember = new RemoveMember( ref id, ref _membershipList, ref _library);
                removeMember.ShowDialog();
                memberSearchButton_Click(sender, e);
            }
            InitializeListView();
        }

        private void memberEditButton_Click(object sender, EventArgs e)
        {

            if (memberListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a member to edit.");
            }
            else
            {
                long id = long.Parse(memberListView.FocusedItem.SubItems[3].Text);
                EditMember editMember = new EditMember(ref id, ref _membershipList);
                editMember.ShowDialog();
                memberSearchButton_Click(sender, e);
            }
        }

        private void memberViewDetails(object sender, EventArgs e)
        {
            if (memberListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a member to view.");
            }
            else
            { 
                // Get the member from the memberID
                ListViewItem item = memberListView.FocusedItem;
                long _id;
                _id = long.Parse(item.SubItems[3].Text);
                Member member = _membershipList.FindById(_id);
                
                ListView checkedOutBooks = new ListView();
                checkedOutBooks.Columns.Add("Title");
                checkedOutBooks.Items.Clear();
                
                ListView reservedBooks = new ListView();
                reservedBooks.Columns.Add("Title");
                reservedBooks.Items.Clear();

                List<LibraryBook> books = _library.Search(member.ToString());

                foreach (LibraryBook book in _library.LibraryList)
                {
                    foreach (BookIdentification copy in book.BookIdent)
                    {
                        if ( copy.Status == Status.CheckedOut && copy.Owner.ToString() == member.ToString() )
                        {
                            ListViewItem cItem = new ListViewItem();
                            cItem.Text = book.Title;
                            checkedOutBooks.Items.Add(cItem);
                            
                        }
                        else if ( copy.Status == Status.Reserved && copy.Owner.ToString() == member.ToString() )
                        {
                            ListViewItem rItem = new ListViewItem();
                            rItem.Text = book.Title;
                            reservedBooks.Items.Add(rItem);
                        }
                    }
                }


                if ( checkedOutBooks.Items.Count == 0 )
                {
                    ListViewItem nItem = new ListViewItem();
                    nItem.Text = "No books checked out";
                    checkedOutBooks.Items.Add(nItem);
                }

                if ( reservedBooks.Items.Count == 0 )
                {
                    ListViewItem nItem = new ListViewItem();
                    nItem.Text = "No books reserved";
                    reservedBooks.Items.Add(nItem);
                }

               

                ViewMemberDetails viewMemberDetails = new ViewMemberDetails(ref member, ref _library, ref checkedOutBooks, ref reservedBooks);
                viewMemberDetails.ShowDialog();
            }
        }

        private void memberListView_DoubleClick(object sender, EventArgs e)
        {
            memberViewDetails(sender, e);
        }

        private void memberSearchButton_Click(object sender, EventArgs e)
        {
            // Get the member that you're looking for
            List<Member> results = _membershipList.Search(memberSearchTextBox.Text);

            //Clear existing list
            memberListView.Items.Clear();

            // populate the list view
            foreach (Member m in results)
            {
                ListViewItem item = new ListViewItem();
                item.Text = m.FirstName;
                item.SubItems.Add(m.Lastname);
                item.SubItems.Add(m.PhoneNumber.ToString());
                item.SubItems.Add(m.MemberId.ToString());
                memberListView.Items.Add(item);
            }
        }

        private void InitRegisterView(List<LibraryBook> results)
        {
            registerListView.Items.Clear();
            foreach (var book in results)
            {
                ListViewItem item = new ListViewItem();
                item.Text = book.Title;
                item.SubItems.Add(book.AuthorLastName);
                item.SubItems.Add(book.AuthorFirstName);
                item.SubItems.Add(book.Isbn.ToString(CultureInfo.InvariantCulture));
                registerListView.Items.Add(item);
            }
            registerListView.View = View.Details;
        }

        private void checkInRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkInRadio.Checked == true)
            {
                if (memberBox.SelectedItem==null)
                {
                    var results = _library.ListCheckedOut();
                    InitRegisterView(results);
                }
                else
                {
                    var results = _membershipList.ListCheckedOut(memberBox.SelectedItem.ToString());
                    
                    InitRegisterView(results);
                }
            }
        }

        private void checkOutRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOutRadio.Checked == true)
            {
                List<LibraryBook> results = _library.ListOnHand(memberBox.SelectedItem as Member);
                InitRegisterView(results);
            }       
        }

        private void reserveRadio_CheckedChanged(object sender, EventArgs e)
        {
            InitRegisterView(_library.LibraryList);
        }

        private void registerCommitButton_Click(object sender, EventArgs e)
        {
            if (registerListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Book.");
            }
            else
            {
                if (checkOutRadio.Checked == true)
                {
                    //checkout code
                    try
                    {
                        _register.CheckOut(long.Parse(registerListView.FocusedItem.SubItems[3].Text), memberBox.SelectedItem as Member);
                        MessageBox.Show("Book Checked Out");
                        checkOutRadio_CheckedChanged(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else if (checkInRadio.Checked == true)
                {
                    try
                    {
                        //checkin code
                        _register.CheckIn(long.Parse(registerListView.FocusedItem.SubItems[3].Text), memberBox.SelectedItem as Member);
                        MessageBox.Show("Book Checked In");
                        checkInRadio_CheckedChanged(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    try
                    {

                        //reserve code
                        if ( memberBox.Text == "" )
                        {
                            MessageBox.Show("Please select a member before reserving a book","Member not selected");
                        }
                        else if (registerListView.SelectedItems.Count == 0)
                        {
                            MessageBox.Show("Please select a book before reserving a book.", "Book not selected");
                        }
                        else
                        {
                            _register.Reserve(long.Parse(registerListView.FocusedItem.SubItems[3].Text), memberBox.SelectedItem as Member);
                            MessageBox.Show("Book Reserved");
                            reserveRadio_CheckedChanged(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void memberBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkInRadio.Checked == true)
            {
                var results = _membershipList.ListCheckedOut(memberBox.SelectedItem.ToString());
                InitRegisterView(results);
            }
            checkOutRadio_CheckedChanged(sender, e);
        }

    }
}
