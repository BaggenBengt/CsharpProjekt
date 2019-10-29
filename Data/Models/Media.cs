using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.Models
{
   public class Media : INameable
    {
        public string Name {get; set;}

       protected virtual int getAntalInList()
        {
            int antal = 0;
            return antal;
        }
    }
}
