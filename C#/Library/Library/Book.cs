using System;
using System.Xml.Serialization;


namespace Library
{
    public abstract class Book
    {
        #region Properties

        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string AuthorFirstName { get; set; }

        [XmlAttribute]
        public string AuthorLastName { get; set; }

        [XmlAttribute]
        public DateTime PublishingDate { get; set; }

        [XmlAttribute("ISBN")]
        public long Isbn { get; set; }

        #endregion

        public Book( ) { }

        public Book(string title, string fName, string lName, long isbn, DateTime pDate)
        {
            Title = title;
            AuthorFirstName = fName;
            AuthorLastName = lName;
            Isbn = isbn;
            PublishingDate = pDate;
        }
    }
}
