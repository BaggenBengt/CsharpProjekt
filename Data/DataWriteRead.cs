using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data.Models;
using Newtonsoft.Json;

namespace Data
{
    public class DataWriteRead
    {

        public void sparaPodcastListaTillJson(List<Podcast> podcastLista)
        {
            var Serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sw = new StreamWriter("sparadepodcasts.Json"))
            {
                    using (var jtw = new JsonTextWriter(sw))
                    {
                    
                        Serializer.Serialize(jtw, podcastLista);

                    }
            }
        }
        public List<Avsnitt> getAvsnittFromUrl(string url)
        {
            var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            List<Avsnitt> PoddensAvsnitt = new List<Avsnitt>();

            foreach(var i in feed.Items)
            {
                Avsnitt avsnitt = new Avsnitt();
                avsnitt.Title = i.Title.Text;
                avsnitt.Beskrivning = i.Summary.Text;
                PoddensAvsnitt.Add(avsnitt);

            }
            return PoddensAvsnitt;
        } 

        public List<Podcast> getSparadPodcastListaFromJson()
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sr = new StreamReader("sparadepodcasts.Json"))
            {
                using (var jtr = new JsonTextReader(sr))
                {
                    List<Podcast> podcastLista = serializer.Deserialize<List<Podcast>>(jtr);
                    return podcastLista;
                }
                
            }
            
        }
    }
}
