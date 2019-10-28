using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Logic
{
    public static class UpdateService
    {
        public static List<Podcast> UpdatedList { get; set; }

        public static List<Podcast> getUpdatedListByTimer(string frekvens)
        {
            startaTimer(frekvens);
            return UpdatedList;
        }
        public static  void startaTimer(string frekvens)
        {
            int tid = 0;
            if (frekvens.Equals("Var 5:e minut"))
            {
                //300000
                tid = 3000;
                Timer timer = new Timer(tid);
                timer.Start();
                timer.Elapsed += Timer_Elapsed5Min;
                timer.AutoReset = true;
            }
            else
            {
                //1200000
                tid = 3000;
                Timer timer = new Timer(tid);
                timer.Start();
                timer.Elapsed += Timer_Elapsed20Min;
                timer.AutoReset = true;
            }

        }


        private static void Timer_Elapsed5Min(object sender, ElapsedEventArgs e)
        {
            DataWriteRead dwr = new DataWriteRead();
            var nuvarandeLista = dwr.getSparadPodcastListaFromJson();

            foreach(Podcast podden in nuvarandeLista)
            {
                if(podden.Frekvens.Equals("Var 5:e minut"))
                {
                  var avsnittLista = podden.AvsnittLista;
                    int countLista = avsnittLista.Count();
                    for (int ind = 0; ind<countLista; ind++)
                    {
                        avsnittLista.RemoveAt(ind);
                    }

                    podden.AvsnittLista = dwr.getAvsnittFromUrl(podden.Url);
                }
            }
            UpdatedList = nuvarandeLista;
 
        }
        private static void Timer_Elapsed20Min(object sender, ElapsedEventArgs e)
        {
            DataWriteRead dwr = new DataWriteRead();
            var nuvarandeLista = dwr.getSparadPodcastListaFromJson();

            foreach (Podcast podden in nuvarandeLista)
            {
                if (podden.Frekvens.Equals("Var 20:e minut"))
                {
                    var avsnittLista = podden.AvsnittLista;
                    foreach (var avsnitt in avsnittLista)
                    {
                        avsnittLista.Remove(avsnitt);
                    }

                    podden.AvsnittLista = dwr.getAvsnittFromUrl(podden.Url);

                }
            }
            UpdatedList = nuvarandeLista;
        }

        
    }
}
