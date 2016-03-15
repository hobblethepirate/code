using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    [XmlInclude(typeof(List<MemberBook>))]
    public class Member
    {
        #region Properties

        [XmlAttribute("MemberId")]
        public long MemberId { get; set; }

        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string Lastname { get; set; }

        [XmlAttribute("AddressLine1")]
        public string AddressLine1 { get; set; }

        [XmlAttribute("AddressLine2")]
        public string AddressLine2 { get; set; }

        [XmlAttribute("City")]
        public string City { get; set; }

        [XmlAttribute("State")]
        public string State { get; set; }

        [XmlAttribute("ZipCode")]
        public int ZipCode { get; set; }

        [XmlAttribute("PhoneNumber")]
        public long PhoneNumber { get; set; }
         
        [XmlArray("MemberBooks")]
        public List<MemberBook> MemberBooks { get; set; }
        
        #endregion

        public Member()
        {
            MemberBooks = new List<MemberBook>();
        }

        public Member(string fName, string lName, string addL1, string addL2, string city, string state, int zip, long phone, long memId)
        {
            MemberId = memId;
            FirstName = fName;
            Lastname = lName;
            AddressLine1 = addL1;
            AddressLine2 = addL2;
            City = city;
            State = state;
            ZipCode = zip;
            PhoneNumber = phone;
        }

        public Boolean Contains(string input)
        {
            /* 
             * See http://stackoverflow.com/questions/444798/case-insensitive-containsstring
             */ 
            if (FirstName.IndexOf(input,0,StringComparison.CurrentCultureIgnoreCase) != -1 ||
                Lastname.IndexOf(input,0,StringComparison.CurrentCultureIgnoreCase) != -1 ||
                AddressLine1.IndexOf(input, 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                AddressLine2.IndexOf(input, 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                City.IndexOf(input, 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                State.IndexOf(input, 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                ZipCode.ToString().IndexOf(input, 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                PhoneNumber.ToString().IndexOf(input, 0, StringComparison.CurrentCultureIgnoreCase) != -1 
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MemberBook FindIndexByIsbn(long isbn)
        {
            MemberBook result = new MemberBook();
            foreach (MemberBook mb in MemberBooks)
            {
                if (mb.Isbn == isbn)
                {
                    return mb;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.Lastname);
        }

    }
}