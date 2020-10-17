using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Covid19
{
    public class Importer
    {
        public List<Mortality> GetMortality()
        {
            List<Mortality> jsonList;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://epistat.sciensano.be/data/covid19be_mort.json");
                jsonList = JsonConvert.DeserializeObject<List<Mortality>>(json);
            }
            return jsonList;
        }

        public List<Case> GetCases()
        {
            List<Case> jsonList;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://epistat.sciensano.be/Data/COVID19BE_CASES_MUNI.json");
                jsonList = JsonConvert.DeserializeObject<List<Case>>(json);
            }
            return jsonList;
        }

        public List<Mortality> ReadMortalityFromXmlFile(string fileName)
        {
            List<Mortality> mortalityList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mortality>));
            using (StreamReader reader = new StreamReader(fileName))
            {
                mortalityList = (List<Mortality>)serializer.Deserialize(reader);
            }
            return mortalityList;
        }

        public List<Case> ReadCasesFromXmlFile(string fileName)
        {
            List<Case> caseList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Case>));
            using (StreamReader reader = new StreamReader(fileName))
            {
                caseList = (List<Case>)serializer.Deserialize(reader);
            }
            return caseList;
        }

        public List<Mortality> ReadMortalityFromJsonFile(string fileName)
        {
            List<Mortality> objects;

            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                objects = (List<Mortality>)serializer.Deserialize(file, typeof(List<Mortality>));
            }
            return objects;
        }
        public List<Case> ReadCasesFromJsonFile(string fileName)
        {
            List<Case> objects;

            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                objects = (List<Case>)serializer.Deserialize(file, typeof(List<Case>));
            }
            return objects;
        }
    }
}
