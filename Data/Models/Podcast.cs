using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        public Timer timer { get; set; }

      
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

            AntalAvsnitt = getAntalAvsnitt();

            startaTimer(Frekvens);
        }

        public void startaTimer(string frekvens)
        {
            if (frekvens.Equals("Var 5:e minut"))
            {
                timer = new Timer(300000);
                timer.AutoReset = true;
                timer.Start();          
                timer.Elapsed += Timer_Elapsed;
                
            }
            else if (frekvens.Equals("Var 20:e minut"))
            {
                timer = new Timer(1200000);
                timer.AutoReset = true;
                timer.Start();
                timer.Elapsed += Timer_Elapsed;
                
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            DataWriteRead dwr = new DataWriteRead();
            AvsnittLista =  dwr.getAvsnittFromUrl(Url);
            AntalAvsnitt = getAntalAvsnitt();
        }

        private int getAntalAvsnitt()
        {
            return AvsnittLista.Count();
        }


    }


}
