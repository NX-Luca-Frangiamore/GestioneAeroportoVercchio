using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Route
    {
        public List<Aereo> Aereo { get; set;}
        public List<Person> Passeggeri { get; set;}
        public City From {  get; set;}
        public City To { get; set;}
        public Data data { get; set;}
    }
}
