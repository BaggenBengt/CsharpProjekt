using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class KategorierLista
    {
        public List<Kategorier> Kategorier {get; set;}

        public KategorierLista()
        {
            Kategorier = new List<Kategorier>();
        }
    }
}
