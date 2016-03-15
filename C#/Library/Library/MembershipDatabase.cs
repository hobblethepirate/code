using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Library
{
    class MembershipDatabase
    {

        private volatile static MembershipDatabase _uniqueInstance;
        private static readonly object SyncRoot = new object();

        private MembershipDatabase() { }

        public static MembershipDatabase GetInstance()
        {

            if (_uniqueInstance == null)
            {
                lock (SyncRoot)
                {
                    if (_uniqueInstance == null) { _uniqueInstance = new MembershipDatabase(); }
                }
            }

            return _uniqueInstance;
        }

        public void SerializeToXml(List<Member> members)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Member>));
            TextWriter textWriter = new StreamWriter(@"memberData.xml");
            serializer.Serialize(textWriter, members);
            textWriter.Close();

        }

        public List<Member> DeserializeFromXml()
        {

            List<Member> members = new List<Member>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Member>));
            if (!File.Exists(@"memberData.xml")) { return members; }
            TextReader textReader = new StreamReader(@"memberData.xml");
            members = (List<Member>)deserializer.Deserialize(textReader);
            textReader.Close();

            return members;
        }   

    }
}
