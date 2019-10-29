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

        public void sparaTillJson(List<Podcast> podcastLista)
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
        public void sparaTillJson(List<Kategorier> kategorierLista)
        {
            var Serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sw = new StreamWriter("kategorier.Json"))
            {
                using (var jtw = new JsonTextWriter(sw))
                {

                    Serializer.Serialize(jtw, kategorierLista);

                }
            }
        }
        public string getPodcastTitleFromUrl(string url)
        {
             var reader = XmlReader.Create(url);
            reader.ReadToFollowing("title");
            string title = reader.ReadElementContentAsString();
             return title;
        }
        public List<Avsnitt> getAvsnittFromUrl(string url)
        {
            var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            List<Avsnitt> PoddensAvsnitt = new List<Avsnitt>();

            foreach(var i in feed.Items)
            {
                Avsnitt avsnitt = new Avsnitt();
                avsnitt.Name = i.Title.Text;
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

        public List<Podcast> getSparadPodcastListaFromJson(string kategori)
        {
            string json = File.ReadAllText("sparadepodcasts.json");
            List<Podcast> podLista = JsonConvert.DeserializeObject<List<Podcast>>(json);
            List<Podcast> podListSortedByKategori = new List<Podcast>();



            foreach (Podcast p in podLista)
            {
                if (kategori == p.Kategori)
                {

                    podListSortedByKategori.Add(p);
                }
            }
            return podListSortedByKategori;

        }

        public void ChangeJsonData(string kategori, string frekvens, int index, string url)
        {

            string json = File.ReadAllText("sparadepodcasts.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj[index]["Kategori"] = kategori;
            jsonObj[index]["Frekvens"] = frekvens;
            jsonObj[index]["Url"] = url;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("sparadepodcasts.json", output);

        }
   
        public List<Podcast> ChangeJsonDataKategori(string nykategori, int index, string oldkategori)
        {

            string json = File.ReadAllText("kategorier.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj[index]["Kategori"] = nykategori;
            

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("kategorier.json", output);
            List<Podcast> podlista = UpdatePodcastsNyKategori(nykategori, oldkategori);
            return podlista;

        }
      
        private List<Podcast> UpdatePodcastsNyKategori(string nykategori, string oldkategori)
        {
            string json = File.ReadAllText("sparadepodcasts.json");
            var items = JsonConvert.DeserializeObject<List<Podcast>>(json);

            foreach(Podcast pod in items)
            {
                if(pod.Kategori == oldkategori)
                {
                    pod.Kategori = nykategori;
                    
                }

            }
            
            var newJsonString = JsonConvert.SerializeObject(items);
            File.WriteAllText("sparadepodcasts.json", newJsonString);
            return items;
        }

        public void DeleteJsonItem(String podcast)
        {
            string json = File.ReadAllText("sparadepodcasts.json");
            var items = JsonConvert.DeserializeObject<List<Podcast>>(json);

            var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.Name != podcast));
            File.WriteAllText("sparadepodcasts.json", newJsonString);

        }
        public List<Podcast> DeleteKategoriFromJson(String kategori)
        {
            if (!kategori.Equals("Ingen Kategori")) {

                string json = File.ReadAllText("kategorier.json");
                var items = JsonConvert.DeserializeObject<List<Kategorier>>(json);

                var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.Kategori != kategori));
                File.WriteAllText("kategorier.json", newJsonString);
                return UpdatePodcastsNyKategori("Ingen Kategori", kategori);

            } 
            else
            {

                string json = File.ReadAllText("kategorier.json");
                var items = JsonConvert.DeserializeObject<List<Kategorier>>(json);

                var newJsonString = JsonConvert.SerializeObject(items);
                File.WriteAllText("kategorier.json", newJsonString);
                return UpdatePodcastsNyKategori("Ingen Kategori", kategori);

            }
           
            
        }

        public List<Kategorier> getKategorierFromJson()
        {
            var serializer = new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (var sr = new StreamReader("kategorier.Json"))
            {
                using (var jtr = new JsonTextReader(sr))
                {
                    List<Kategorier> kategorierLista = serializer.Deserialize<List<Kategorier>>(jtr);
                    return kategorierLista;
                }

            }

        }

        public void CreateJsonFile()
        {
            if (!File.Exists("sparadepodcasts.Json"))
            {
                using (File.Create("sparadepodcats.Json")) { } ;

            }

            if(!File.Exists("kategorier.Json")){

                using (File.Create("kategorier.Json")) ;
            
            }

        }

    }
}
