using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class Podcast
    {
        public string Name { get; set; }
        public string Url {get; set;}
        public string Frekvens {get; set;}
        public string Kategori { get; set;}
        public List<Avsnitt> Avsnitt { get; set; }
        public int AntalAvsnitt { get; set; }

        public Podcast()
        {

        }

        public Podcast(string url, string kategori, string frekvens)
        {
            Url = url;
            Kategori = kategori;
            Frekvens = frekvens;

        }
    }
}
