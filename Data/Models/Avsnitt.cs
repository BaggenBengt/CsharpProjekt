using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
    public class Avsnitt : Media
    {
        public string Beskrivning { get; set; }
        public string Title { get; set; }

        public Avsnitt(){}

        public Avsnitt(string beskrivning, string title)
        {
            Beskrivning = beskrivning;
            Title = title;
        }

    }


}
