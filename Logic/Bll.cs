using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data;
using Newtonsoft.Json;

namespace Logic
{
    public static class Bll
    {
        public static string Path { get; set; }
        public static void skickaUrl(string url)
        {
            var dWR = new DataWriteRead();
            dWR.readURL(url);
            Path = dWR.Path;

        }

        public static List<Avsnitt> getAvsnitt()
        {

            var reader = XmlReader.Create(Path);
            var feed = SyndicationFeed.Load(reader);

            List<Avsnitt> poddensAvsnitt = new List<Avsnitt>();

            //Loop through all items in the SyndicationFeed
            foreach (var i in feed.Items)
            {
                Avsnitt avsnitt = new Avsnitt();
                avsnitt.Title = i.Title.Text;
                avsnitt.Beskrivning = i.Summary.Text;
                poddensAvsnitt.Add(avsnitt);
            }

            return poddensAvsnitt;
        }

        private static string objToString(PodcastLista obj)
        {
            string objToString = JsonConvert.SerializeObject(obj);
            return objToString;
        }

        public static void sparaTillJsonFil(PodcastLista lista)
        {
            DataWriteRead dWR = new DataWriteRead();
            dWR.savePodcasts(objToString(lista));
        }

        public static PodcastLista GetDataFromJson()
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sr = new StreamReader("file.Json"))
            {
                using (var jtr = new JsonTextReader(sr))
                {
                    PodcastLista str = serializer.Deserialize<PodcastLista>(jtr);
                    return str;
                }
            }

        }
    }
}
