using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PodcastLista
    {
        public List<Podcast> podcasts { get; set; }

        public PodcastLista()
        {
            podcasts = new List<Podcast>();
        }
    }
}
