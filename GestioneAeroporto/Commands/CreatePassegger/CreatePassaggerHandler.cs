
using Dominio;
using Dominio.Validation;
using FluentResults;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Core.Commands.CreateRoute
{
    static class MethodToCreatePassegger
    {
        internal static Passegger SetPersonalInfomation(this Passegger p, string nome, string cognome,int Etá)
        {
            p.Name = nome;
            p.Cognome = cognome;
            p.Etá = Etá;
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
            newPassegger.SetPersonalInfomation(command.Nome, command.Cognome,command.Etá)
            .AddLuggage(command.Luggages)
            .SetTicket(command.TypeTicket);

            if(ValidatePassegger(newPassegger))
               return newPassegger;
            return Result.Fail("Impossibile creare il passeggero");
        }
        private bool ValidatePassegger(Passegger newPassegger)
        {
            PasseggerValidator validator=new();
            return validator.Validate(newPassegger).IsValid;
        }

       

    }
}
