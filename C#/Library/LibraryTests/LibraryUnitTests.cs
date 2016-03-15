using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace LibraryTests
{
    /// <summary>
    /// LibraryUnitTests- contains all tests meant to test the library class & sub-classes.
    /// </summary>
    [TestClass]
    public class LibraryUnitTests
    {
        private TestContext testContextInstance;
        private Library.Library testLib;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        /// <summary>
        /// AddBook - Submit Title "" returns Error Dialog : Title
        /// </summary>
        [TestMethod]
        public void STR005TEST001()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 1; //result 1 stands for bad title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting an empty title is returning the wrong results");
            }
        }

        /// <summary>
        /// AddBook - Submit Title " " returns Error Dialog : Title
        /// </summary>
        [TestMethod]
        public void STR005TEST002()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook(" ", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 1; //result 1 stands for bad title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting an empty title is returning the wrong results");
            }
        }

        /// <summary>
        ///  AddBook - Submit Title "Valid Book Title!"	No Error 
        /// </summary>
        [TestMethod]
        public void STR005TEST003()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("Valid Book Title!", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 0; //result 0 stands for good title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a valid title is returning the wrong results");
            }
        }

        /// <summary>
        /// AddBook - Submit Title "Valid Book Title"	No Error 
        /// </summary>
        [TestMethod]
        public void STR005TEST004()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("Valid Book Title", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 0; //result 0 stands for good title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a valid title is returning the wrong results");
            }
        }

        /// <summary>
        ///  AddBook - Submit Title "Valid Book Title1"	No Error 
        /// </summary>
        [TestMethod]
        public void STR005TEST005()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("Valid Book Title1", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 0; //result 0 stands for good title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a valid title is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit First Name "" Error: First Name
        /// </summary>
        [TestMethod]
        public void STR005TEST006()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 2; //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a space for an Author First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit First Name " " Error: First Name
        /// </summary>
        [TestMethod]
        public void STR005TEST007()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", " ", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 2; //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a space for an Author First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit First Name "Michael1" Error : First Name
        /// </summary>
        [TestMethod]
        public void STR005TEST008()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Michael1", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 2;  //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a non-alphabetical Author First Name is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit First Name "James!" Error : First Name
        /// </summary>
        [TestMethod]
        public void STR005TEST009()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "James!", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 2;  //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a non-alphabetical First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit First Name "Dustin"  No Error 
        /// </summary>
        [TestMethod]
        public void STR005TEST010()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Dustin", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 0;  //result 0 stands for a good first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a good First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit Last Name "" Error: LastName
        /// </summary>
        [TestMethod]
        public void STR005TEST011()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "", "1234567891234", "3", "25", "1995");
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit Last Name " " Error: LastName
        /// </summary>
        [TestMethod]
        public void STR005TEST012()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", " ", "1234567891234", "3", "25", "1995");
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Last Name "Luevane1" Error: LastName
        /// </summary>
        [TestMethod]
        public void STR005TEST013()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Luevane1", "1234567891234", "3", "25", "1995");
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Last Name "Shaver!" Error: LastName
        /// </summary>
        [TestMethod]
        public void STR005TEST014()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Shaver!", "1234567891234", "3", "25", "1995");
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Last Name "Kerns" no error
        /// </summary>
        [TestMethod]
        public void STR005TEST015()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Kerns", "1234567891234", "3", "25", "1995");
            int expected = 0;  //result 0 stands for good edit.
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a good author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit ISBN "" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR005TEST016()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "", "3", "25", "1995");
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit ISBN " " error: ISBN
        /// </summary>
        [TestMethod]
        public void STR005TEST017()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", " ", "3", "25", "1995");
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit ISBN "Serendipitous" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR005TEST018()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "Serendipitous", "3", "25", "1995");
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit ISBN "!!!!!!!!!!!!!" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR005TEST019()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "!!!!!!!!!!!!!", "3", "25", "1995");
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit ISBN "-123456789123" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR005TEST020()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "-123456789123", "3", "25", "1995");
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        ///AddBook - Submit ISBN "1234567891234" no error
        /// </summary>
        [TestMethod]
        public void STR005TEST021()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int expected = 0;  //result 0 stands for good input
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit Publishing Date ""/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST022()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "", "2", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Publishing Date "01"/""/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST023()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "1", "", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Publishing Date "01"/"02"/"" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST024()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "1", "02", "");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit Publishing Date "00"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST025()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "00", "02", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Publishing Date "13"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST026()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "13", "02", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Publishing Date "01"/"00"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST027()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "00", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Publishing Date "1"/"32"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST028()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "32", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }
        /// <summary>
        /// AddBook - Submit a Publishing Date in the future. error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST029()
        {
            testLib = new Library.Library();

            //getting the current date and setting it to sometime in the future.
            DateTime test = DateTime.Now;
            test = test.AddDays(3);
            test = test.AddMonths(4);
            test = test.AddYears(5);

            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", test.Month.ToString(), test.Day.ToString(), test.Year.ToString());
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// AddBook - Submit Publishing Date "CC"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST030()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "CC", "02", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }

        /// <summary>
        /// AddBook - Submit Publishing Date "01"/"CC"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST031()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "CC", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }

        /// <summary>
        /// AddBook - Submit Publishing Date "01"/"02"/"CCCC" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST032()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "02", "CCCC");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// AddBook - Submit Publishing Date "!!"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST033()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "!!", "02", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// AddBook - Submit Publishing Date "01"/"!!"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST034()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "!!", "2013");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// AddBook - Submit Publishing Date "01"/"02"/"!!!!" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR005TEST035()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "02", "!!!!");
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// AddBook - Submit Publishing Date "02"/"08"/"2013" no error
        /// </summary>
        [TestMethod]
        public void STR005TEST036()
        {
            testLib = new Library.Library();
            int actual = testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "02", "08", "2013");
            int expected = 0;  //result 0 stands for a good publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a good publishing date is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Title "" returns Error Dialog : Title
        /// </summary>
        [TestMethod]
        public void STR007TEST001()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("", "Carl", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 1; //result 1 stands for bad title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting an empty title is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Title " " returns Error Dialog : Title
        /// </summary>
        [TestMethod]
        public void STR007TEST002()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook(" ", "Carl", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 1; //result 1 stands for bad title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting an empty title is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Title "Valid Book Title!"	No Error 
        /// </summary>
        [TestMethod]
        public void STR007TEST003()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("Valid Book Title!", "Carl", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 0; //result 0 stands for good title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a valid title is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Title "Valid Book Title"	No Error 
        /// </summary>
        [TestMethod]
        public void STR007TEST004()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("Valid Book Title", "Carl", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 0; //result 0 stands for good title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a valid title is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Title "Valid Book Title1"	No Error 
        /// </summary>
        [TestMethod]
        public void STR007TEST005()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("Valid Book Title1", "Carl", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 0; //result 0 stands for good title
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a valid title is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit First Name "" Error: First Name
        /// </summary>
        [TestMethod]
        public void STR007TEST006()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 2; //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a space for an Author First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit First Name " " Error: First Name
        /// </summary>
        [TestMethod]
        public void STR007TEST007()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", " ", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 2; //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a space for an Author First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit First Name "Michael1" Error : First Name
        /// </summary>
        [TestMethod]
        public void STR007TEST008()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Michael1", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 2;  //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a non-alphabetical Author First Name is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit First Name "James!" Error : First Name
        /// </summary>
        [TestMethod]
        public void STR007TEST009()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "James!", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 2;  //result 2 stands for a Bad Author's first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a non-alphabetical First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit First Name "Dustin"  No Error 
        /// </summary>
        [TestMethod]
        public void STR007TEST010()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Dustin", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 0;  //result 0 stands for a good first name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a good First Name is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit Last Name "" Error: LastName
        /// </summary>
        [TestMethod]
        public void STR007TEST011()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "", "1234567891234", "3", "25", "1995", 0);
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit Last Name " " Error: LastName
        /// </summary>
        [TestMethod]
        public void STR007TEST012()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", " ", "1234567891234", "3", "25", "1995", 0);
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Last Name "Luevane1" Error: LastName
        /// </summary>
        [TestMethod]
        public void STR007TEST013()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Luevane1", "1234567891234", "3", "25", "1995", 0);
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Last Name "Shaver!" Error: LastName
        /// </summary>
        [TestMethod]
        public void STR007TEST014()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Shaver!", "1234567891234", "3", "25", "1995", 0);
            int expected = 3;  //result 3 stands for a bad last name
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Last Name "Kerns" no error
        /// </summary>
        [TestMethod]
        public void STR007TEST015()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Kerns", "1234567891234", "3", "25", "1995", 0);
            int expected = 0;  //result 0 stands for good edit.
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a good author last name is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit ISBN "" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR007TEST016()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "", "3", "25", "1995", 0);
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit ISBN " " error: ISBN
        /// </summary>
        [TestMethod]
        public void STR007TEST017()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", " ", "3", "25", "1995", 0);
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit ISBN "Serendipitous" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR007TEST018()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "Serendipitous", "3", "25", "1995", 0);
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit ISBN "!!!!!!!!!!!!!" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR007TEST019()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "!!!!!!!!!!!!!", "3", "25", "1995", 0);
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit ISBN "-123456789123" error: ISBN
        /// </summary>
        [TestMethod]
        public void STR007TEST020()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "-123456789123", "3", "25", "1995", 0);
            int expected = 4;  //result 4 stands for a bad isbn
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit ISBN "1234567891234" no error
        /// </summary>
        [TestMethod]
        public void STR007TEST021()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995", 0);
            int expected = 0;  //result 0 stands for good input
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad ISBN is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit Publishing Date ""/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST022()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "", "2", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Publishing Date "01"/""/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST023()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "1", "", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Publishing Date "01"/"02"/"" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST024()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "1", "02", "", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit Publishing Date "00"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST025()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "00", "02", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Publishing Date "13"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST026()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "13", "02", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Publishing Date "01"/"00"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST027()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "00", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Publishing Date "1"/"32"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST028()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "32", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }
        /// <summary>
        /// Submit a Publishing Date in the future. error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST029()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            
            //getting the current date and setting it to sometime in the future.
            DateTime test = DateTime.Now;
            test = test.AddDays(3);
            test = test.AddMonths(4);
            test = test.AddYears(5);

            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", test.Month.ToString(), test.Day.ToString(), test.Year.ToString(), 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }

        }

        /// <summary>
        /// Submit Publishing Date "CC"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST030()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");

            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "CC", "02", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Publishing Date "01"/"CC"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST031()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "CC", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }

        /// <summary>
        /// Submit Publishing Date "01"/"02"/"CCCC" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST032()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "02", "CCCC", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// Submit Publishing Date "!!"/"02"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST033()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "!!", "02", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// Submit Publishing Date "01"/"!!"/"2013" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST034()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "!!", "2013", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// Submit Publishing Date "01"/"02"/"!!!!" error: Publishing Date
        /// </summary>
        [TestMethod]
        public void STR007TEST035()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "01", "02", "!!!!", 0);
            int expected = 5;  //result 5 stands for a bad publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a bad publishing date is returning the wrong results");
            }
        }
        /// <summary>
        /// Submit Publishing Date "02"/"08"/"2013" no error
        /// </summary>
        [TestMethod]
        public void STR007TEST036()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            int actual = testLib.EditBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "02", "08", "2013", 0);
            int expected = 0;  //result 0 stands for a good publishing date
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Submitting a good publishing date is returning the wrong results");
            }
        }


        /// <summary>
        /// Search "", expected: returns the list of all books
        /// This test assumes we are dealing with an empty library.
        /// </summary>
        [TestMethod]
        public void STR008TEST001()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            testLib.AddBook("A Random Book", "Captain", "Crunch", "1234657891234", "4", "12", "1994");
            List<LibraryBook> expected = testLib.LibraryList;
            List<LibraryBook> actual = testLib.Search("");
            try
            {
                int aLen = actual.ToArray().Length;
                int eLen = expected.ToArray().Length;
                if (aLen == eLen)
                {
                    int a = 0;
                    foreach (LibraryBook i in actual)
                    {
                        Assert.AreEqual(actual[a].Title, expected[a].Title);
                        Assert.AreEqual(actual[a].AuthorFirstName, expected[a].AuthorFirstName);
                        Assert.AreEqual(actual[a].AuthorLastName, expected[a].AuthorLastName);
                        Assert.AreEqual(actual[a].Isbn, expected[a].Isbn);
                        Assert.AreEqual(actual[a].PublishingDate, expected[a].PublishingDate);
                        a++;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("The empty string is not returning the proper search results");
            }
        }
         /// <summary>
        /// Search "Carl", expected: returns results that have Carl in them.
        /// This test assumes we are dealing with an empty library.
        /// </summary>
        [TestMethod]
        public void STR008TEST002()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            string name = "Carl";
            List<LibraryBook> expected = new List<LibraryBook>();

            foreach (LibraryBook i in testLib.LibraryList)
            {
                if (i.AuthorFirstName.Contains(name) || i.AuthorLastName.Contains(name) || i.Isbn.ToString().Equals(name))
                {
                    expected.Add(i);
                }
                
            }
            List<LibraryBook> actual = testLib.Search(name);
            try
            {
                int aLen = actual.ToArray().Length;
                int eLen = expected.ToArray().Length;
                if (aLen == eLen)
                {
                    int a = 0;
                    foreach (LibraryBook i in actual)
                    {
                        Assert.AreEqual(actual[a].Title, expected[a].Title);
                        Assert.AreEqual(actual[a].AuthorFirstName, expected[a].AuthorFirstName);
                        Assert.AreEqual(actual[a].AuthorLastName, expected[a].AuthorLastName);
                        Assert.AreEqual(actual[a].Isbn, expected[a].Isbn);
                        Assert.AreEqual(actual[a].PublishingDate, expected[a].PublishingDate);
                        a++;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("The string Carl is not returning the proper search results");
            }

        }

        /// <summary>
        /// Search "Sagan", expected: returns results that have Sagan in them.
        /// This test assumes we are dealing with an empty library.
        /// </summary>
        [TestMethod]
        public void STR008TEST003()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            string name = "Sagan";
            List<LibraryBook> expected = new List<LibraryBook>();

            foreach (LibraryBook i in testLib.LibraryList)
            {
                if (i.AuthorFirstName.Contains(name) || i.AuthorLastName.Contains(name) || i.Isbn.ToString().Equals(name))
                {
                    expected.Add(i);
                }

            }
            List<LibraryBook> actual = testLib.Search(name);
            try
            {
                int aLen = actual.ToArray().Length;
                int eLen = expected.ToArray().Length;
                if (aLen == eLen)
                {
                    int a = 0;
                    foreach (LibraryBook i in actual)
                    {
                        Assert.AreEqual(actual[a].Title, expected[a].Title);
                        Assert.AreEqual(actual[a].AuthorFirstName, expected[a].AuthorFirstName);
                        Assert.AreEqual(actual[a].AuthorLastName, expected[a].AuthorLastName);
                        Assert.AreEqual(actual[a].Isbn, expected[a].Isbn);
                        Assert.AreEqual(actual[a].PublishingDate, expected[a].PublishingDate);
                        a++;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("The string Sagan is not returning the proper search results");
            }
        }

        /// <summary>
        /// Search "A Demon Haunted World", expected: Returns "A Demon Haunted World"
        /// This test assumes we are dealing with an empty library.
        /// </summary>
        [TestMethod]
        public void STR008TEST004()
        {
            testLib = new Library.Library();
            testLib.AddBook("A Demon Haunted World", "Carl", "Sagan", "1234567891234", "3", "25", "1995");
            string name = "A Demon Haunted World";
            List<LibraryBook> expected = new List<LibraryBook>();

            foreach (LibraryBook i in testLib.LibraryList)
            {
                if (i.Title.Contains(name)||i.AuthorFirstName.Contains(name) || i.AuthorLastName.Contains(name) || i.Isbn.ToString().Equals(name))
                {
                    expected.Add(i);
                }

            }
            List<LibraryBook> actual = testLib.Search(name);
            try
            {
                int aLen = actual.ToArray().Length;
                int eLen = expected.ToArray().Length;
                if (aLen == eLen)
                {
                    int a = 0;
                    foreach (LibraryBook i in actual)
                    {
                        Assert.AreEqual(actual[a].Title, expected[a].Title);
                        Assert.AreEqual(actual[a].AuthorFirstName, expected[a].AuthorFirstName);
                        Assert.AreEqual(actual[a].AuthorLastName, expected[a].AuthorLastName);
                        Assert.AreEqual(actual[a].Isbn, expected[a].Isbn);
                        Assert.AreEqual(actual[a].PublishingDate, expected[a].PublishingDate);
                        a++;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("A Demon Haunted World is not returning the proper search results");
            }
        }

        /// <summary>
        /// Search book not in library
        /// This test assumes we are dealing with an empty library.
        /// </summary>
        [TestMethod]
        public void STR008TEST005()
        {
            
            testLib = new Library.Library();
            List<LibraryBook> results = testLib.Search("The Dark Knight");
            int expected = 0;
            int actual = results.ToArray().Length;
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("Searching for non-existent book is returning results.");
            }

            
        }

    }
}
