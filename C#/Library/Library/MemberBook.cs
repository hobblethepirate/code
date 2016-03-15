using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    [XmlInclude(typeof(BookIdentification))]
    public class MemberBook : Book
    {
        #region Properties
        [XmlAttribute]
        public long BookId { get; set; }

        [XmlAttribute]
        public Status Status { get; set; }

        #endregion

        public MemberBook()
        {
        }

        public MemberBook ( string title, string fName, string lName, long isbn, DateTime pDate) : base ( title, fName, lName, isbn, pDate)
        {
        }
    }
}

