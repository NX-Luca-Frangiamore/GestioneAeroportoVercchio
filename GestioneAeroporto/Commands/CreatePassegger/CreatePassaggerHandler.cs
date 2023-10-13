
using Dominio;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Core.Commands.CreateRoute
{
    static class MethodToCreatePassegger
    {
        internal static Passegger SetPersonalInfomation(this Passegger p, string nome, string cognome)
        {
            p.Name = nome;
            p.Cognome = cognome;
            return p;
        }
        internal static Passegger AddLuggage(this Passegger p, List<CreateLuggageCommand>? luggages)
        {
            if (luggages is null) return p;

            luggages.ForEach(l => {
                var luggage = new Luggage
                {
                    Peso = l.Peso,
                    Dimensione = l.Dimensione,
                };
                p.Luggages.Add(luggage); 
            
            });
            
            return p;
        }
        internal static Passegger SetTicket(this Passegger p,TypeClass ticket)
        {
            p.TypeTicket = ticket.ToString();
            return p;
        }
    }
    internal class CreatePassaggerHandler
    {
        public Result<Passegger> CreatePassegger(CreatePasseggerCommand command) {

            var newPassegger = new Passegger();
            newPassegger.SetPersonalInfomation(command.Nome, command.Cognome)
            .AddLuggage(command.Luggages)
            .SetTicket(command.TypeTicket);

            if(ValidatePassegger(newPassegger))
               return newPassegger;
            return new PasseggerExeption();
        }
        private bool ValidatePassegger(Passegger newPassegger)
        {
            return true;
        }

       

    }
}
