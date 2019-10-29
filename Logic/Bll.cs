using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        public List<Kategorier> allaKategorier { get; set; }

        public DataWriteRead dWR { get; set; }
        public Bll()
        {
            allaPodcasts = new List<Podcast>();
            allaPodcastsSorterade = new List<Podcast>();
            allaKategorier = new List<Kategorier>();    
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
                    string avsnittTitle = avsnitt.Name.ToString();
                    allaAvsnittToString.Add(avsnittTitle);
                }
            }
            return allaAvsnittToString;
        }
        public string getUrlfromPodcast(string name)
        {
            var sortedList = getPodcastListByName(name);
            var url = "";

            foreach(var pod in sortedList)
            {
                url = pod.Url;


            }

            return url;
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
                    if (avsnitt.Name.Equals(name))
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

        public void nyKategori(string kategori)
        {
            Kategorier nyKategori = new Kategorier(kategori);
            addNyKategoriToList(nyKategori);
        }

        private void addNyKategoriToList(Kategorier nyKategori)
        {
            allaKategorier.Add(nyKategori);

        }

        public void sparaPodcastLista()
        {
            
            dWR.sparaTillJson(allaPodcasts);
        }

        public void sparaKategorierLista()
        {
            dWR.sparaTillJson(allaKategorier);

        }

        public void getSparadPodcastLista()
        {
            
            allaPodcasts = dWR.getSparadPodcastListaFromJson();
        }
        public void getSparadKategorierLista()
        {
            allaKategorier = dWR.getKategorierFromJson();

        }
      

        public List<List<string>> ConvertPodcastListToString(string val) 
        {
            var podcastlista = new List<Podcast>();
            
            switch(val){
                case "HelaListan":
                    podcastlista = allaPodcasts;
                    break;
                case "SorteradKategori":
                    podcastlista = allaPodcastsSorterade;
                    break;
            }
            var allPodcastsInString = new List<List<string>>();
            var podcastProperty = new List<string>();
            
            foreach (Podcast podcast in podcastlista)
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
        public List<string> ConvertKategorierListToString()
        {
            

        
            
            var kategoriNamnList = new List<string>();

            foreach (Kategorier kategori in allaKategorier)
            {
                var namnkategori = kategori.Kategori;

                kategoriNamnList.Add(namnkategori);
       

               

            }
            return kategoriNamnList;
        }



        public void ChangeJsonData(string kategori, string frekvens, int index, string url)
        {
           
            dWR.ChangeJsonData(kategori, frekvens, index, url);

        }

        public void DeleteJsonItem(string podcastnamn)
        {
            
            dWR.DeleteJsonItem(podcastnamn);

        }

        public void DeleteKategoriFromJson(string kategori)
        {
           allaPodcastsSorterade = dWR.DeleteKategoriFromJson(kategori);

        }
        public void SorteraEfterKategori(string kategori)
       
        {
            
            allaPodcastsSorterade = dWR.getSparadPodcastListaFromJson(kategori);
        }

        public void ChangeKategori(string nykategori, int index, string oldkategori)
        {
           allaPodcasts = dWR.ChangeJsonDataKategori(nykategori, index, oldkategori);


        }
        public void CreateJsonFile()
        {
            dWR.CreateJsonFile();

        }
       
        public List<Podcast> getPodcastListByFrekvens(string frekvens)
        {

            return allaPodcasts.Where((pod) => pod.Frekvens.Equals(frekvens))
                .ToList();
        }
        

        public void StartaTimer()
        {
            foreach (var pod in allaPodcasts)
            {
                pod.startaTimer(pod.Frekvens);
            }
        }

      
    }
}
