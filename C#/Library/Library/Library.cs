using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Library class- is a class used to create library object that a user can run normal library operations on.
    /// librarylist is the list of LibraryBook objects in the library. currentId is the current id number of the 
    /// next book to be added.
    /// 
    /// Created by the Green Team
    /// </summary>
    public class Library
    {

        private long _currentId;
        public List<LibraryBook> LibraryList { get; set; }

        // Create a new LibraryBookDatabase object to Load/Save the library inventory
        private readonly LibraryBookDatabase _libData = LibraryBookDatabase.GetInstance();

        public Library()
        {
            _currentId = 1;
            LibraryList = new List<LibraryBook>();
            LoadData();
        }

        public int AddBook(string title, string fName, string lName, string isbn, string month, string day, string year)
        {

            DateTime pDate = new DateTime();
            long result = 1;
            
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Please enter a Title");
            }
            else if (string.IsNullOrWhiteSpace(fName) ||
                System.Text.RegularExpressions.Regex.IsMatch(fName, "^[a-zA-Z]+$") == false)
            {
                throw new Exception("Please enter a valid first name");
            }
            else if (string.IsNullOrWhiteSpace(lName) ||
                System.Text.RegularExpressions.Regex.IsMatch(lName, "^[a-zA-Z]+$") == false)
            {
                throw new Exception("Please enter a valid last name");
            }
            else if (string.IsNullOrWhiteSpace(isbn) ||
                  isbn.Length != 13 || long.TryParse(isbn, out result) == false || result < 0)
            {
                throw new Exception("Please enter a valid ISBN-13");
            } 
            else
            {
                if (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(day) || string.IsNullOrWhiteSpace(year))                
                {
                    throw new Exception("Please enter a valid date");
                } 
                else
                {
                    try
                    {
                        pDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        DateTime cDate = DateTime.Now;
                        if (pDate.Year > cDate.Year || (pDate.Year == cDate.Year && pDate.Month > cDate.Month)|| (pDate.Year==cDate.Year && pDate.Month==cDate.Month && pDate.Day > cDate.Day))
                        {
                            throw new Exception("Please enter a valid date");
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Please enter a valid date");
                    }
                }

            }

            //check whether the book exists in the library
            foreach (LibraryBook book in LibraryList)
            {
                if ((!book.Title.Equals(title) || !book.AuthorFirstName.Equals(fName) || !book.AuthorLastName.Equals(lName) || !book.PublishingDate.Equals(pDate)) && book.Isbn == long.Parse(isbn))
                {
                    throw new Exception("ISBN-13 already exists for another book");
                }
            }

            //check whether the book exists in the library
            foreach (LibraryBook book in LibraryList)
            {
                if (book.Title.Equals(title) && book.AuthorFirstName.Equals(fName) && book.AuthorLastName.Equals(lName)
                    && book.Isbn == long.Parse(isbn) && book.PublishingDate.Equals(pDate))
                {
                    book.AddBookIdentification(_currentId++);
                    SaveData();
                    return 0;
                }
            }

            //if it doesn't exist in the current library it is added
            LibraryBook addition = new LibraryBook(title, fName, lName, long.Parse(isbn), pDate, _currentId++);
            LibraryList.Add(addition);
            SaveData();
            return 0;
        }

        public bool RemoveBook(List<LibraryBook> book, long bookId )
        {
            foreach (LibraryBook libraryListBook in LibraryList)
            {
                foreach (LibraryBook libBook in book)
                {
                    if (libraryListBook.Isbn.Equals(libBook.Isbn))
                    {
                        if (libraryListBook.BookIdent.Count == 1)
                        {
                            LibraryList.Remove(libraryListBook);
                            SaveData();
                            return true;
                        }

                        foreach (BookIdentification bookIdent in libBook.BookIdent)
                        {
                            if (bookIdent.BookId.Equals(bookId))
                            {
                                libBook.BookIdent.Remove(bookIdent);
                                SaveData();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Search- Checks through the Library for books matching a given input. If a Library Book is found that matches
        /// the input it is added to a list. The list of books found is returned. 
        /// </summary>
        /// <param name="input">string to look for</param>
        /// <returns>A list object of search results.</returns>
        public List<LibraryBook> Search(string input)
        {
            List<LibraryBook> bookList = new List<LibraryBook>();
            if (input.Equals("") == true)
            {
                bookList = LibraryList;
                return bookList;
            }
            else
            {
                foreach (LibraryBook i in LibraryList)
                {
                    if (i.Contains(input) == true)
                    {
                        bookList.Add(i);
                    }
                }
                return bookList;
            }

        }

        public Boolean ResetById(long id)
        {
            LibraryBook result = new LibraryBook();
            foreach (LibraryBook a in LibraryList)
            {
                foreach (BookIdentification b in a.BookIdent)
                {
                    if (b.BookId == id)
                    {
                        b.Status = Status.OnHand;
                        b.Owner = new Member("CST236 Library", "Library Inventory", "1457 Institute of Advanced Studies", "Math & Computer Science Department", "Hillsboro", "Oregon", 97124, 4501234578, 1);
                    }
                }
            }
            return false;;
        }

        /// <summary>
        /// EditBook - Takes an existing book and edits any of it's fields except book id, books that have the same name will be changed as well during the edit.
        /// </summary>
        /// <param name="title"> Book Title</param>
        /// <param name="fName">Author's First Name</param>
        /// <param name="lName">Author's Last Name</param>
        /// <param name="isbn">13 digit ISBN for the book</param>
        /// <param name="month">Publishing Month</param>
        /// <param name="day">Publishing Day</param>
        /// <param name="year">Publishing Month</param>
        /// <param name="pos">Postion in the library list</param>
        /// <returns></returns>
        public int EditBook(string title, string fName, string lName, string isbn, string month, string day, string year, int pos)
        {
            DateTime pDate;
            long result=1;


            if (string.IsNullOrWhiteSpace(title))
            {
                return 1;
            }
            else if (string.IsNullOrWhiteSpace(fName) ||
                System.Text.RegularExpressions.Regex.IsMatch(fName, "^[a-zA-Z]+$") == false)
            {
                return 2;
            }
            else if (string.IsNullOrWhiteSpace(lName) ||
                System.Text.RegularExpressions.Regex.IsMatch(lName, "^[a-zA-Z]+$") == false)
            {
                return 3;
            }
            else if (string.IsNullOrWhiteSpace(isbn) ||
                 isbn.Length != 13 || long.TryParse(isbn, out result)==false || result < 0 )
            {
                return 4;
            } 
            else
            {
                if (string.IsNullOrWhiteSpace(month) || string.IsNullOrWhiteSpace(day) || string.IsNullOrWhiteSpace(year))
                {
                    return 5;
                }
                else
                {
                    try
                    {
                        pDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        DateTime cDate = DateTime.Now;
                        if (pDate.Year > cDate.Year || (pDate.Year == cDate.Year && pDate.Month > cDate.Month) || (pDate.Year == cDate.Year && pDate.Month == cDate.Month && pDate.Day > cDate.Day))
                        {
                            return 5;
                        }
                    }
                    catch (Exception)
                    {
                        return 5;
                    }
                }

            }

            //manipulate the change book object so the ids are the same as the old book, but has the new 
            LibraryBook change = new LibraryBook();
            change.Title = title;
            change.AuthorFirstName = fName;
            change.AuthorLastName = lName;
            try
            {
                change.Isbn = Convert.ToInt64(isbn);
            }
            catch (Exception)
            {
                //gracefully don't add anything but return an error
                return 4;
            }

            change.PublishingDate = pDate;
            change.BookIdent = LibraryList[pos].BookIdent;
            LibraryList[pos] = change;
            SaveData();
            return 0;
        }

        public List<LibraryBook> ListCheckedOut()
        {
            List<LibraryBook> results = new List<LibraryBook>();
            foreach (LibraryBook i in LibraryList)
            {
                foreach (BookIdentification j in i.BookIdent)
                {
                    if (j.Status == Status.CheckedOut)
                    {
                        results.Add(i);
                        break;
                    }
                }
            }
            return results;
        }

        public List<LibraryBook> ListOnHand(Member member)
        {
            List<LibraryBook> results = new List<LibraryBook>();
            foreach (LibraryBook i in LibraryList)
            {
                foreach (BookIdentification j in i.BookIdent)
                {
                    if (j.Status == Status.OnHand || (j.Status == Status.Reserved && j.Owner == member))
                    {
                        results.Add(i);
                        break;
                    }
                }
            }
            return results;
        }

        private void LoadData()
        {
            LibraryList = _libData.DeserializeFromXml();

            long maxId = 0;

            foreach (LibraryBook libraryBook in LibraryList)
            {
                foreach (BookIdentification bookId in libraryBook.BookIdent)
                {
                    if (bookId.BookId >= maxId) { maxId = bookId.BookId; }
                }
            }

            _currentId = maxId + 1;

        }

        public void SaveData()
        {

            _libData.SerializeToXml(LibraryList);

        }

    }
}