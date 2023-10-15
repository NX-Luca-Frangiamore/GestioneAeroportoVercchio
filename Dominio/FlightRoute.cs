using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
namespace Dominio
{
    public record City(string Name,string Cap);
    public record Data(int gg,int m,int h);
    public record Ora(int h,int mm);
    public class FlightRoute
    {
        public string Id { get; set; }
        public required City From { get; set; }
        public required City To { get; set; }
        public required Data Data { get; set; }
        public required int NSeatsLeft { get; set; }
    }
    
}
