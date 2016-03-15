using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Library
{
    /// <summary>
    /// This class handles writing the LibraryBook lists to and from a .XML file
    /// </summary>
    public class LibraryBookDatabase
    {

        private static volatile LibraryBookDatabase _uniqueInstance;
        private static readonly object SyncRoot = new object();

        private LibraryBookDatabase() { }

        public static LibraryBookDatabase GetInstance()
        {

            if (_uniqueInstance == null)
            {
                lock (SyncRoot)
                {
                    if (_uniqueInstance == null) { _uniqueInstance = new LibraryBookDatabase(); }
                }
            }

            return _uniqueInstance;
        }

        /// <summary>
        /// Serializes the LibraryBook list and writes it to a .XML file
        /// </summary>
        /// <param name="libraryInv"></param>
        public void SerializeToXml(List<LibraryBook> libraryInv)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<LibraryBook>));
            TextWriter textWriter = new StreamWriter(@"libBookData.xml");
            serializer.Serialize(textWriter, libraryInv);
            textWriter.Close();

        }

        /// <summary>
        /// Deserializes the data from "libBookData.xml" and returns it as list
        /// </summary>
        /// <returns></returns>
        public List<LibraryBook> DeserializeFromXml()
        {
            
            List<LibraryBook> books = new List<LibraryBook>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<LibraryBook>));
            if (!File.Exists(@"libBookData.xml")) { return books; }
            TextReader textReader = new StreamReader(@"libBookData.xml");
            books = (List<LibraryBook>)deserializer.Deserialize(textReader);
            textReader.Close();
            return books;

        }       
    }
}
