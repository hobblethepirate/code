using ChatGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChatServer;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class is created to run unit tests on the Connection class while using
    ///the teacher's given Chat server class.
    ///</summary>
    [TestClass()]
    public class ConnectionTest
    {


        private TestContext testContextInstance;

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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        /// <summary>
        ///A test for Connected method, creates a server instance and then starts
        ///the connection thread on it with the same address. Checks to see if the
        ///connection is connected under a good data and known running server.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ChatGUI.exe")]
        public void ConnectedTest()
        {
            ChatService cs = new ChatService(4000);
            Connection_Accessor target = new Connection_Accessor(); 
            target.StartConnectionThread("127.0.0.1:4000");
            bool expected = true;
            bool actual = target.Connected();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Please double check your connection method to make sure it returning the proper value");
            cs.Shutdown();
        }

        /// <summary>
        ///A test for Disconnect to make sure it disconnects from the given server.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ChatGUI.exe")]
        public void DisconnectTest()
        {
            ChatService cs = new ChatService(4000);
            Connection_Accessor target = new Connection_Accessor();
            target.StartConnectionThread("127.0.0.1:4000");
            target.Disconnect();
            bool expected = false;
            bool actual = target.Connected();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Please double check your Disconnect method to make sure it returning the proper value.");
            cs.Shutdown();
        }

        /// <summary>
        ///A test for DisconnectAndQuit, making sure the disconnect value is changed.
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ChatGUI.exe")]
        public void DisconnectAndQuitTest()
        {
            ChatService cs = new ChatService(4000);
            Connection_Accessor target = new Connection_Accessor();
            target.StartConnectionThread("127.0.0.1:4000");
            bool expected = false;
            bool actual = target.Connected();
            Assert.AreEqual(expected, actual);
            
            target.DisconnectAndQuit();

            Assert.Inconclusive("Please double check your DisconnectAndQuit method to make sure it returning the proper value.");
            cs.Shutdown();
        }

        
    }
}
