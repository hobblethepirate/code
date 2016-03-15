using System;
using System.Windows.Forms;

namespace Library
{
    public partial class AddBook : Form
    {
        private Library _library;

        public AddBook(ref Library library)
        {
            InitializeComponent();
            _library = library;

        }

        private void addCommitButton_Click(object sender, EventArgs e)
        {
            try
            {
                int results = _library.AddBook(addTitleTextBox.Text, addAFirstTextBox.Text, addALastTextBox.Text,
                                 addIsbnTextBox.Text, addMonthTextBox.Text, addDayTextBox.Text, addYearTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Book successfully added!");
            this.Close();
                
            }

        }
    }

