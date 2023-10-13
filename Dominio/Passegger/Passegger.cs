using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Passegger
    {
        public string Name { get; set; }
        public string Cognome { get; set; }
        public int Seat { get; set; }
        public string TypeTicket { get; set; }
        public List<Luggage> Luggages { get; set; }
    }
}
