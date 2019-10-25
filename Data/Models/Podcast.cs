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
        public string Name { get; set; }
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
            Name = "test";

            var dWR = new DataWriteRead();
            AvsnittLista = dWR.getAvsnittFromUrl(url);

            AntalAvsnitt = getAntalAvsnitt();
        }

        private int getAntalAvsnitt()
        {
            return AvsnittLista.Count();
        }
    }
}
