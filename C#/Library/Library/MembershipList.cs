using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Library
{
    public class MembershipList
    {

        private long _currentId;

        [XmlArray]
        public List<Member> MemberList { get; set; }

        private readonly MembershipDatabase _membershipDatabaseData = MembershipDatabase.GetInstance();

        public MembershipList()
        {

            _currentId = 1;
            MemberList = new List<Member>();
            LoadData();
        
        }

        public int AddMember(string fName, 
                             string lName, 
                             string addressLine1,
                             string addressLine2, 
                             string city, 
                             string state, 
                             string zipCode, 
                             string phoneNumber)
        {
            int zip;
            long phone;

            try
            {
               zip = int.Parse(zipCode);
            }
            catch (Exception)
            {
                throw new System.Exception("Please enter a valid zip code");
            }

            try
            {
                phone = long.Parse(phoneNumber);
            }
            catch (Exception)
            {
                throw new System.Exception("Please enter a valid phone number");
            }

            if (string.IsNullOrWhiteSpace(fName) ||
                System.Text.RegularExpressions.Regex.IsMatch(fName, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid first name.");
            }
            else if (string.IsNullOrWhiteSpace(lName) ||
                System.Text.RegularExpressions.Regex.IsMatch(lName, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid last name.");
            }
            else if (string.IsNullOrWhiteSpace(addressLine1))
            {
                throw new System.Exception("Please enter a valid address line 1.");
            }
            else if (addressLine2.Length > 0 && addressLine2.Trim().Length == 0)
            {
                throw new System.Exception("Please enter a valid address line 2.");
            }
            else if (string.IsNullOrWhiteSpace(city) ||
                System.Text.RegularExpressions.Regex.IsMatch(city, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid city.");
            }
            else if (string.IsNullOrWhiteSpace(state) ||
                System.Text.RegularExpressions.Regex.IsMatch(state, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid state");
            }
            else if (string.IsNullOrWhiteSpace(zipCode) ||
                zip < 0 || zipCode.Length != 5)
            {
                throw new System.Exception("Please enter a valid zip code.");
            }
            else if (string.IsNullOrWhiteSpace(phoneNumber) ||
                phone < 0 || phoneNumber.Length != 10)
            {
                throw new System.Exception("Please enter a valid phone number.");
            }

            //check whether the member exists in the library
            foreach (Member member in MemberList)
            {
                if (member.FirstName.Equals(fName) && member.Lastname.Equals(lName) && member.PhoneNumber.Equals(phone))
                {
                    throw new System.Exception("This member already exists in the database.");
                }
            }

            //if it doesn't exist in the current library it is added
            Member addition = new Member(fName, lName, addressLine1, addressLine2, city, state, zip, phone, _currentId++);
            MemberList.Add(addition);
            SaveData();
            return 0;

        }

        public bool RemoveMember(long id)
        {
            Member member = FindById(id);
            if (member == null)
            {
                return false;
            }
            MemberList.Remove(member);
            SaveData();
            return true;
        }




        public Boolean Contains(string Input)
        {
            return false;
        }

        public int EditMember(string fName,
                              string lName,
                              string addressLine1,
                              string addressLine2,
                              string city,
                              string state,
                              string zipCode,
                              string phoneNumber,
                              long id)
        {

            int zip;
            long phone;

            // Check for invalid zipcode input
            try
            {
                zip = int.Parse(zipCode);
            }
            catch (Exception)
            {
                throw new System.Exception("Please enter a valid zip code");
            }

            // Check for invalid phone input
            try
            {
                phone = long.Parse(phoneNumber);
            }
            catch (Exception)
            {
                throw new System.Exception("Please enter a valid phone number");
            }

            // Boundary and Negative tests
            if (string.IsNullOrWhiteSpace(fName) ||
                System.Text.RegularExpressions.Regex.IsMatch(fName, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid first name.");
            }
            else if (string.IsNullOrWhiteSpace(lName) ||
                System.Text.RegularExpressions.Regex.IsMatch(lName, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid last name.");
            }
            else if (string.IsNullOrWhiteSpace(addressLine1))
            {
                throw new System.Exception("Please enter a valid address line 1.");
            }
            else if (addressLine2.Length > 0 && addressLine2.Trim().Length == 0)
            {
                throw new System.Exception("Please enter a valid address line 2.");
            }
            else if (string.IsNullOrWhiteSpace(city) ||
                System.Text.RegularExpressions.Regex.IsMatch(city, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid city.");
            }
            else if (string.IsNullOrWhiteSpace(state) ||
                System.Text.RegularExpressions.Regex.IsMatch(state, "^[a-zA-Z]+$") == false)
            {
                throw new System.Exception("Please enter a valid state");
            }
            else if (string.IsNullOrWhiteSpace(zipCode) ||
                zip < 0 || zipCode.Length != 5)
            {
                throw new System.Exception("Please enter a valid zip code.");
            }
            else if (string.IsNullOrWhiteSpace(phoneNumber) ||
                phone < 0 || phoneNumber.Length != 10)
            {
                throw new System.Exception("Please enter a valid phone number.");
            }

            //check whether the member exists in the library
            foreach (Member member in MemberList)
            {
                if (member.MemberId != id && member.FirstName.Equals(fName) && member.Lastname.Equals(lName) && member.PhoneNumber.Equals(phone))
                {
                    throw new System.Exception("This member already exists in the database.");
                }
            }

            foreach (Member i in MemberList)
            {
                if (i.MemberId == id)
                {
                    i.FirstName = fName;
                    i.Lastname = lName;
                    i.AddressLine1 = addressLine1;
                    i.AddressLine2 = addressLine2;
                    i.City = city;
                    i.State = state;
                    try
                    {
                        i.ZipCode = int.Parse(zipCode);
                    }
                     catch
                    {
                        return 7;
                    }
                    try
                    {
                        i.PhoneNumber = long.Parse(phoneNumber);
                    }
                    catch
                    {
                        return 8;
                    }
                }
            }
            SaveData();
            return 0;
        }
       
        /// <summary>
        /// FindById - Searches through the memberlist and returns a member of that id, if it fails to find it, null is returned.
        /// </summary>
        /// <param name="id"> id number of the Member to be found</param>
        /// <returns>Member which the id matches to or null</returns>
        public Member FindById(long id)
        {
            foreach (Member i in MemberList)
            {
                if (i.MemberId == id)
                {
                    return i;
                }
            }
            return null;
        }

        /// <summary>
        /// FindByAny - Searches through the memberlist and returns a list of the members that contain that string
        /// </summary>
        /// <param name="input">Search string</param>
        /// <returns>List of members</returns>
        public Member FindByAny(string input)
        {

            foreach (Member i in MemberList)
            {
                if (i.FirstName.IndexOf(input) != 0 ||
                    i.Lastname.IndexOf(input) != 0 ||
                    i.AddressLine1.IndexOf(input) != 0 ||
                    i.AddressLine2.IndexOf(input) != 0 ||
                    i.City.IndexOf(input) != 0 ||
                    i.ZipCode.ToString().IndexOf(input) != 0 ||
                    i.PhoneNumber.ToString().IndexOf(input) != 0)
                {
                    return i;
                }
            }
            return null;
        }

        public List<LibraryBook> ListCheckedOut(string name)
        {
            List<LibraryBook> libBook = new List<LibraryBook>();
            foreach (Member i in MemberList)
            {
                if (name.Equals(i.FirstName + " " + i.Lastname)==true)
                {
                    // Iterate through all memberbooks
                    foreach (var memBk in i.MemberBooks)
                    {
                        // Convert each book to LibBook
                        var temp = new LibraryBook();
                        temp.Title = memBk.Title;
                        temp.AuthorFirstName = memBk.AuthorFirstName;
                        temp.AuthorLastName = memBk.AuthorLastName;
                        temp.Isbn = memBk.Isbn;
                        temp.PublishingDate = memBk.PublishingDate;

                        var bookIdentity = new BookIdentification();
                        bookIdentity.Owner = i;
                        bookIdentity.Status = memBk.Status;
                        bookIdentity.BookId = memBk.BookId;
                        temp.BookIdent.Add(bookIdentity);

                        // Add book to LibBook list to return
                        libBook.Add(temp);
                    }
                    return libBook;
                }
            }
            return null;
        }

        public List<Member> Search(string input)
        {
            List<Member> foundMemberList = new List<Member>();

            if (input.Equals("") == true)
            {
                foundMemberList = MemberList;
                return foundMemberList;
            }
            else
            {
                foreach (Member m in MemberList)
                {
                    if (m.Contains(input) == true)
                    {
                        foundMemberList.Add(m);
                    }
                }
            }
            return foundMemberList;
        }

        private void LoadData()
        {

            MemberList = _membershipDatabaseData.DeserializeFromXml();

            long maxId = 0;

            foreach (Member member in MemberList)
            {
                if (member.MemberId >= maxId) { maxId = member.MemberId; }
            }

            _currentId = maxId + 1;     
            
        }

        public void SaveData()
        {

            _membershipDatabaseData.SerializeToXml(MemberList);
        
        }

    }
}
