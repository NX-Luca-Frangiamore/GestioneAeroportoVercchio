using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public record City(string Name,string Cap);
    public record Data(int gg,int m,int h);
    public record Ora(int h,int mm);
    class Route
    {
        List<Passegger> passeggers;
        public City From { get; set; }
        public City To { get; set; }
        public Data Data { get; set; }
    }
}
