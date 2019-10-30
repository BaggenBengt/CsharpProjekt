using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Data
{
    public class DataWriteRead
    {

        public void sparaTillJson(List<Podcast> podcastLista)
        {
            try
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
            catch (Exception ex)
            {

            }
        }
        public void sparaTillJson(List<Kategorier> kategorierLista)
        {
            try
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
            catch (Exception ex)
            {

            }
        }
        public string getPodcastTitleFromUrl(string url)
        {
            string title = "";
            try
            {
                var reader = XmlReader.Create(url);
                reader.ReadToFollowing("title");
                title = reader.ReadElementContentAsString();
                return title;
            }
            catch (Exception ex)
            {
                return title;
            }
        }
        public List<Avsnitt> getAvsnittFromUrl(string url)
        {
            List<Avsnitt> PoddensAvsnitt = new List<Avsnitt>();
            try
            {
                var reader = XmlReader.Create(url);
                var feed = SyndicationFeed.Load(reader);
                foreach (var i in feed.Items)
                {
                    Avsnitt avsnitt = new Avsnitt();
                    avsnitt.Name = i.Title.Text;
                    avsnitt.Beskrivning = i.Summary.Text;
                    PoddensAvsnitt.Add(avsnitt);

                }
                return PoddensAvsnitt;
            }
            catch (Exception ex)
            {
                return PoddensAvsnitt;
            }
        }

        public List<Podcast> getSparadPodcastListaFromJson()
        {
            List<Podcast> podcastLista = new List<Podcast>();
            try
            {

                var serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                using (var sr = new StreamReader("sparadepodcasts.Json"))
                {
                    using (var jtr = new JsonTextReader(sr))
                    {
                        podcastLista = serializer.Deserialize<List<Podcast>>(jtr);
                        return podcastLista;
                    }

                }
            }
            catch (Exception ex)
            {
                return podcastLista;
            }
        }

        public List<Podcast> getSparadPodcastListaFromJson(string kategori)
        {
            List<Podcast> podListSortedByKategori = new List<Podcast>();
            try
            {
                string json = File.ReadAllText("sparadepodcasts.json");
                List<Podcast> podLista = JsonConvert.DeserializeObject<List<Podcast>>(json);




                foreach (Podcast p in podLista)
                {
                    if (kategori == p.Kategori)
                    {

                        podListSortedByKategori.Add(p);
                    }
                }
                return podListSortedByKategori;
            }
            catch (Exception ex)
            {
                return podListSortedByKategori;
            }
        }

        public void ChangeJsonData(string kategori, string frekvens, int index, string url)
        {
            try
            {
                string json = File.ReadAllText("sparadepodcasts.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj[index]["Kategori"] = kategori;
                jsonObj[index]["Frekvens"] = frekvens;
                jsonObj[index]["Url"] = url;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("sparadepodcasts.json", output);
            }
            catch (Exception ex)
            {

            }
        }

        public List<Podcast> ChangeJsonDataKategori(string nykategori, int index, string oldkategori)
        {
            List<Podcast> podlista = new List<Podcast>();
            try
            {
                string json = File.ReadAllText("kategorier.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj[index]["Kategori"] = nykategori;


                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("kategorier.json", output);
                podlista = UpdatePodcastsNyKategori(nykategori, oldkategori);
                return podlista;
            }
            catch (Exception ex)
            {
                return podlista;
            }
        }

        private List<Podcast> UpdatePodcastsNyKategori(string nykategori, string oldkategori)
        {

            string json = File.ReadAllText("sparadepodcasts.json");
            var items = JsonConvert.DeserializeObject<List<Podcast>>(json);
            try
            {


                foreach (Podcast pod in items)
                {
                    if (pod.Kategori == oldkategori)
                    {
                        pod.Kategori = nykategori;

                    }

                }

                var newJsonString = JsonConvert.SerializeObject(items);
                File.WriteAllText("sparadepodcasts.json", newJsonString);
                return items;
            }
            catch (Exception ex)
            {
                return items;
            }
        }

        public void DeleteJsonItem(String podcast)
        {
            try
            {
                string json = File.ReadAllText("sparadepodcasts.json");
                var items = JsonConvert.DeserializeObject<List<Podcast>>(json);

                var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.Name != podcast));
                File.WriteAllText("sparadepodcasts.json", newJsonString);
            }
            catch (Exception ex)
            {

            }

        }
        public List<Podcast> DeleteKategoriFromJson(String kategori)
        {
            

                    string json = File.ReadAllText("kategorier.json");
                    var items = JsonConvert.DeserializeObject<List<Kategorier>>(json);

                    var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.Kategori != kategori));
                    File.WriteAllText("kategorier.json", newJsonString);
                    return UpdatePodcastsNyKategori("Ingen Kategori", kategori);

        
           
            
        }

        public List<Kategorier> getKategorierFromJson()
        {
            List<Kategorier> kategorierLista = new List<Kategorier>();
            try
            {
                var serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                using (var sr = new StreamReader("kategorier.Json"))
                {
                    using (var jtr = new JsonTextReader(sr))
                    {
                        kategorierLista = serializer.Deserialize<List<Kategorier>>(jtr);
                        return kategorierLista;
                    }

                }
            }
            catch (Exception ex)
            {
                return kategorierLista;
            }

        }

        public void CreateJsonFile()
        {
            try {
                var tomPodcastLisa = new List<Podcast>();
                var kategori = new Kategorier("Ingen Kategori");
                var KategoriLista = new List<Kategorier>();
                KategoriLista.Add(kategori);

                if (!File.Exists("sparadepodcasts.Json"))
                {
                    var Serializer = new JsonSerializer
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    using (var sw = new StreamWriter("sparadepodcasts.Json"))
                    {
                        using (var jtw = new JsonTextWriter(sw))
                        {

                            Serializer.Serialize(jtw, tomPodcastLisa);

                        }
                    }
                }

                if (!File.Exists("kategorier.Json"))
                {

                    var Serializer = new JsonSerializer
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    using (var sw = new StreamWriter("kategorier.Json"))
                    {
                        using (var jtw = new JsonTextWriter(sw))
                        {

                            Serializer.Serialize(jtw, KategoriLista);

                        }
                    }

                }

            }
            catch (Exception ex)
            {

            }

    }
    } }
