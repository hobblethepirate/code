using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class Register
    {

        #region Members
        private readonly Library _library = new Library();
        private readonly MembershipList _membershipList = new MembershipList();
        #endregion

        #region Init()
        public Register(ref Library lib, ref MembershipList memlist)
        {
            _library = lib;
            _membershipList = memlist;
        }
        #endregion

        #region Methods

        public void CheckOut(long isbn, Member member)
        {

            // Check if member has book checked out already
            foreach (var memberBook in member.MemberBooks)
            {
                if (memberBook.Isbn == isbn && memberBook.Status == Status.CheckedOut)
                {
                    // Member already has a copy of the book checked out
                    throw new Exception("Member already has a copy of the book");
                }
            }

            // Find the library book by ISBN
            LibraryBook temp = null;
            foreach (var librarybook in _library.LibraryList)
            {
                if (librarybook.Isbn == isbn)
                {
                    // Book was found
                    temp = librarybook;
                    break;
                }
            }

            // Verify book was found
            if (temp == null)
            {
                throw new Exception("Book was not found in the library");
            }
            
            // Change owner and status of first "Reserved" Book Identity
            BookIdentification checkedOutBookId = null;
            foreach (var bkId in temp.BookIdent)
            {
                if (bkId.Status == Status.Reserved && bkId.Owner.MemberId == member.MemberId)
                {
                    // Check out the book Id
                    bkId.Status = Status.CheckedOut;
                    bkId.Owner = member;
                    checkedOutBookId = bkId;

                    // Add library book with checked out Identity to the member
                    foreach (var m in _membershipList.MemberList)
                    {
                        // Found the member
                        if (m.MemberId == member.MemberId)
                        {
                            // Alter the book record
                            foreach (var memberBook in m.MemberBooks)
                            {
                                if (memberBook.BookId == bkId.BookId)
                                {
                                    memberBook.Status = Status.CheckedOut;
                                    return;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            // Check out unreserved book
            if (checkedOutBookId == null)
            {
                foreach (var bkId in temp.BookIdent)
                {
                    if (bkId.Status == Status.OnHand)
                    {
                        // Check out the book Id
                        bkId.Status = Status.CheckedOut;
                        bkId.Owner = member;
                        checkedOutBookId = bkId;
                        break;
                    }
                }
            }

            // Copy book information to MemberBook
            MemberBook membook = new MemberBook();
            membook.Title = temp.Title;
            membook.AuthorFirstName = temp.AuthorFirstName;
            membook.AuthorLastName = temp.AuthorLastName;
            membook.Isbn = temp.Isbn;
            membook.PublishingDate = temp.PublishingDate;
            membook.BookId = checkedOutBookId.BookId;
            membook.Status = checkedOutBookId.Status;

            // Add library book with checked out Identity to the member
            foreach (var m in _membershipList.MemberList)
            {
                // Found the member
                if (m.MemberId == member.MemberId)
                {
                    // Add the book record
                    member.MemberBooks.Add(membook);
                    _membershipList.SaveData();
                    _library.SaveData();
                    break;
                }
            }
        }

        public void CheckIn( long isbn, Member member)
        {
            //first remove the member's memberbook
            MemberBook result= new MemberBook();
            foreach (Member m in _membershipList.MemberList)
            {
                if (member.FirstName.Equals(m.FirstName) && member.Lastname.Equals(m.Lastname))
                {
                    result = m.FindIndexByIsbn(isbn);
                    m.MemberBooks.Remove(result);
                    break;
                }
            }
            //next adjust the library's librarybook
            List<LibraryBook> results =_library.Search(result.Title);
            foreach (LibraryBook lb in results)
            {
              foreach(BookIdentification bi in lb.BookIdent)
              {
                  if (result.BookId == bi.BookId)
                  {
                      bi.Status = Status.OnHand;
                      bi.Owner = new Member("CST236 Library", "Library Inventory", "1457 Institute of Advanced Studies", "Math & Computer Science Department", "Hillsboro", "Oregon", 97124, 4501234578, 1);
                      _membershipList.SaveData();
                      _library.SaveData();
                      return;
                  }
              }
            }

            throw new Exception("Check In failed, bad or non-existent book given");
        }

        public void Reserve( long isbn, Member member )
        {


            // Check if member has book checked out already
            foreach (var memberBook in member.MemberBooks)
            {
                if (memberBook.Isbn == isbn)
                {
                    // Member already has a copy of the book checked out
                    throw new Exception("Member has already reserved a copy of the book");
                }
            }

            // Find the library book by ISBN
            LibraryBook temp = null;
            foreach (var librarybook in _library.LibraryList)
            {
                if (librarybook.Isbn == isbn)
                {
                    // Book was found
                    temp = librarybook;
                    break;
                }
            }

            // Verify book was found
            if (temp == null)
            {
                throw new Exception("Book was not found in the library");
            }

            // Change owner and status of first "OnHand" Book Identity
            BookIdentification checkedOutBookId = null;
            foreach (var bkId in temp.BookIdent)
            {
                if (bkId.Status == Status.OnHand)
                {
                    // Check out the book Id
                    bkId.Status = Status.Reserved;
                    bkId.Owner = member;
                    checkedOutBookId = bkId;
                    break;
                }
                else if (bkId.Status == Status.CheckedOut)
                {
                    throw new Exception(temp.Title+" is already checked out by "+bkId.Owner.FirstName+" "+bkId.Owner.Lastname +". Please reserve a different book");
                }
            }

            // Copy book information to MemberBook
            MemberBook membook = new MemberBook();
            membook.Title = temp.Title;
            membook.AuthorFirstName = temp.AuthorFirstName;
            membook.AuthorLastName = temp.AuthorLastName;
            membook.Isbn = temp.Isbn;
            membook.PublishingDate = temp.PublishingDate;
            membook.BookId = checkedOutBookId.BookId;
            membook.Status = checkedOutBookId.Status;

            // Add library book with checked out Identity to the member
            foreach (var m in _membershipList.MemberList)
            {
                // Found the member
                if (m.MemberId == member.MemberId)
                {
                    // Add the book record
                    member.MemberBooks.Add(membook);
                    _membershipList.SaveData();
                    _library.SaveData();
                    break;
                }
            }
        }

        #endregion

    }
}
