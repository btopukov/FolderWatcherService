using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BradyCodeChallenge.Infrastructure.Interfaces;

namespace BradyCodeChallenge.Common.Serializer
{
    public class Serializer : ISerializer
    {
        T ISerializer.Deserialize<T>(string input)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T objectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize);
                return textWriter.ToString();
            }
        }

        public void SerializeToFile<T>(T objectToSerialize, string outputPath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            using (FileStream file = System.IO.File.Create(outputPath))
            {
                xmlSerializer.Serialize(file, objectToSerialize);
            }
        }
    }
}
