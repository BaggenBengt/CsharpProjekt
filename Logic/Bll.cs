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


        public DataWriteRead dWR { get; set; }
        public Bll()
        {
            allaPodcasts = new List<Podcast>();
            allaPodcastsSorterade = new List<Podcast>();
             dWR = new DataWriteRead(); 
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

        public string getAvsnittBeskrivningByAvsnittName (string name)
        {
            string avsnittBeskrivning = "";
            foreach (Podcast pod in allaPodcasts)
            {
                var avsnittlista = pod.AvsnittLista;
                foreach (Avsnitt avsnitt in avsnittlista)
                {
                    if (avsnitt.Title.Equals(name))
                    {
                        avsnittBeskrivning = avsnitt.Beskrivning;
                    }
                }
            }
            return avsnittBeskrivning;                   
                               
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
            
            dWR.sparaPodcastListaTillJson(allaPodcasts);
        }

        public void getSparadPodcastLista()
        {
            
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
           
            dWR.ChangeJsonData(kategori, frekvens, index);

        }

        public void DeleteJsonItem(string podcastnamn)
        {
            
            dWR.DeleteJsonItem(podcastnamn);

        }
        public  void SorteraEfterKategori(string kategori)
        {
            
            allaPodcastsSorterade = dWR.SorteraEfterKategori(kategori);
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
       
        public List<Podcast> getPodcastListByFrekvens(string frekvens)
        {

            return allaPodcasts.Where((pod) => pod.Frekvens.Equals(frekvens))
                .ToList();
        }
        public async Task startTimer(string frekvens)
        {
            
            allaPodcasts = await Task.Run(() => UpdateService.getUpdatedListByTimer(frekvens));
        }

    }
}
