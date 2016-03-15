using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    [XmlInclude(typeof(List<BookIdentification>))]
    public class LibraryBook : Book
    {

        // This property holds a list of specific book ids, owners, and their states
        [XmlArray]
        public List<BookIdentification> BookIdent { get; set; }

        public LibraryBook( ) 
        {
            BookIdent = new List<BookIdentification>();
        }

        public LibraryBook(string title, string fName, string lName, long isbn, DateTime pDate,
              long id) : base(title, fName, lName, isbn, pDate)
        {
            BookIdent = new List<BookIdentification>();
            AddBookIdentification(id);
        }

        // Adds another BookIdentification to the list assigns book id based on self contained counter
        public void AddBookIdentification(long idCounter)
        {
            BookIdent.Add(new BookIdentification(idCounter));
        }

        /// <summary>
        /// Contains - searches a Library Book's Title , Author's First Name, Author's Last Name, and ISBN to see if it contains a given input.
        /// </summary>
        /// <param name="input">Input that is being looked for in the library book</param>
        /// <returns>True if the input is found in either the Library Book's Title , Author's First Name, Author's Last Name, and ISBN. False if not found at all. </returns>
        public Boolean Contains(string input)
        {
            if (Title.Contains(input) == true||AuthorFirstName.Contains(input)==true|| AuthorLastName.Contains(input)==true|| Isbn.ToString().Equals(input))
            {
                return true;
            }
            return false;
        }

        public void RemoveBookIdentification()
        {

        }

    }
}