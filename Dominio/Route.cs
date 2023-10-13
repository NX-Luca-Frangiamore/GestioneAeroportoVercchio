using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    record City(string Name,string Cap);
    record Data(int gg,int m,int h);
    record Ora(int h,int mm);
    class Route
    {
        List<Passegger> passeggers;
        public City From { get; set; }
        public City To { get; set; }
        public Data Data { get; set; }
    }
}
