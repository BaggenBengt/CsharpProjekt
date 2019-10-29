using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Kategorier
    {
        public string Kategori { get; set; }


        public Kategorier(string kategori)
        {
            Kategori = kategori;
        }
    }
}
