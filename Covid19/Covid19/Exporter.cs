using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Covid19
{
    public class Exporter
    {
        public void WriteXmlFile(List<Mortality> collection, string fileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Mortality>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                x.Serialize(writer, collection);
            }
        }
        public void WriteXmlFile(List<Case> collection, string fileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Case>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                x.Serialize(writer, collection);
            }
        }
        public void WriteJsonFile(List<Mortality> collection, string fileName)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, collection);
            }
        }
        public void WriteJsonFile(List<Case> collection, string fileName)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, collection);
            }
        }
    }
}
