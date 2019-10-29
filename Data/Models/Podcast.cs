using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
   public class Podcast : Media
    {
        public string Name {get; set; }
        public string Url {get; set;}
        public string Frekvens {get; set;}
        public string Kategori { get; set;}
        public List<Avsnitt> AvsnittLista { get; set; }
        public int AntalAvsnitt { get; set; }

        public Podcast()
        {

        }

        public Podcast(string url, string kategori, string frekvens)
        {
            Url = url;
            Kategori = kategori;
            Frekvens = frekvens;

            var dWR = new DataWriteRead();
            AvsnittLista = dWR.getAvsnittFromUrl(url);
            Name = dWR.getPodcastTitleFromUrl(url);

            AntalAvsnitt = getAntalInList();
        }

        protected override int getAntalInList()
        {
            return AvsnittLista.Count();
        }
    }
}
