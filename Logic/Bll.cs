using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data;

namespace Logic
{
    public static class Bll
    {
        
        public static void skickaUrl(string url)
        {
            var dWR = new DataWriteRead();
            dWR.readURL(url);
            getAvsnitt(dWR.Path);
            
        }

        private static List<Avsnitt> getAvsnitt(string path)
        {
            
                var reader = XmlReader.Create(path);
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
        

    }
}
