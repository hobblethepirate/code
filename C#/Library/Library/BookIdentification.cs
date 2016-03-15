using System;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    public class BookIdentification
    {
        [XmlAttribute]
        public long BookId { get; set; }

        [XmlElement("Owner")]
        public Member Owner { get; set; }   // Null = Library owns book

        [XmlAttribute]
        public Status Status { get; set; }

        public BookIdentification( ) { }

        public BookIdentification(long val)
        {
            BookId = val;
            Owner = new Member("CST236 Library", "Library Inventory", "1457 Institute of Advanced Studies", "Math & Computer Science Department", "Hillsboro", "Oregon", 97124, 4501234578, 1);
            Status = Status.OnHand;
        }
    }

    // This enumeration changed the meaning of OnHand, Reserved, CheckedOut from Quantity of books in a state, to a specific books current state
    public enum Status
    {
        OnHand,
        Reserved,
        CheckedOut
    }


}
