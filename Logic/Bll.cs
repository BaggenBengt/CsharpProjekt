using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data;
using Data.Models;
using Newtonsoft.Json;

namespace Logic
{
    public class Bll
    {
        public List<Podcast> allaPodcasts { get; set; }
        public List<Podcast> allaPodcastsSorterade { get; set; }
        public Bll()
        {
            allaPodcasts = new List<Podcast>();
            allaPodcastsSorterade = new List<Podcast>();
           

        }
        public List<string> getPodcastAvsnittToString(string name)
        {
            List<string> allaAvsnittToString = new List<string>();
            var sortedPodcastListByName = getPodcastListByName(name);

            foreach(var podcast in sortedPodcastListByName)
            {
                List<Avsnitt> allaAvsnitt = podcast.AvsnittLista;

                foreach (var avsnitt in allaAvsnitt)
                {
                    string avsnittTitle = avsnitt.Title.ToString();
                    allaAvsnittToString.Add(avsnittTitle);
                }
            }
            return allaAvsnittToString;
        }
        private List<Podcast> getPodcastListByName(string name)
        {
            return allaPodcasts
                               .Where(pod => pod.Name.Equals(name))
                               .ToList();

        }
        public void nyPodcast(string url, string kategori, string frekvens)
        {
            Podcast nyPodcast = new Podcast(url, kategori, frekvens);
            addNyPodcastToList(nyPodcast);
        }

        private void addNyPodcastToList(Podcast nyPodcast)
        {
            allaPodcasts.Add(nyPodcast);
        }

        public void sparaPodcastLista()
        {
            var dWR = new DataWriteRead();
            dWR.sparaPodcastListaTillJson(allaPodcasts);
        }

        public void getSparadPodcastLista()
        {
            var dWR = new DataWriteRead();
            allaPodcasts = dWR.getSparadPodcastListaFromJson();
        }

        public List<List<string>> ConvertPodcastListToString() 
        {
            var allPodcastsInString = new List<List<string>>();
            var podcastProperty = new List<string>();
            foreach (Podcast podcast in allaPodcasts)
            {
                var kategori = podcast.Kategori;
                var antalavsnitt = podcast.AntalAvsnitt.ToString();
                var frekvens = podcast.Frekvens;
                var name = podcast.Name;

                podcastProperty.Add(name);
                podcastProperty.Add(antalavsnitt);
                podcastProperty.Add(frekvens);
                podcastProperty.Add(kategori);

                allPodcastsInString.Add(podcastProperty);
               
            }
            return allPodcastsInString;
        }



        public void ChangeJsonData(string kategori, string frekvens, int index)
        {
            var dWr = new DataWriteRead();
            dWr.ChangeJsonData(kategori, frekvens, index);

        }

        public void DeleteJsonItem(string podcastnamn)
        {
            var dWr = new DataWriteRead();
            dWr.DeleteJsonItem(podcastnamn);

        }
        public void SorteraEfterKategori(string kategori)
        {
            var dWr = new DataWriteRead();
            allaPodcastsSorterade = dWr.SorteraEfterKategori(kategori);
        }

        public List<List<string>> ConvertPodcastListToStringByKategori()
        {
            var allPodcastsInString = new List<List<string>>();
            var podcastProperty = new List<string>();
            foreach (Podcast podcast in allaPodcastsSorterade)
            {
                var kategori = podcast.Kategori;
                var antalavsnitt = podcast.AntalAvsnitt.ToString();
                var frekvens = podcast.Frekvens;
                var name = podcast.Name;

                podcastProperty.Add(name);
                podcastProperty.Add(antalavsnitt);
                podcastProperty.Add(frekvens);
                podcastProperty.Add(kategori);

                allPodcastsInString.Add(podcastProperty);

            }
            return allPodcastsInString;
        }

    }
}
