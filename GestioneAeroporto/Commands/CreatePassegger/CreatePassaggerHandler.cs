using SimpleSoft.Mediator;
using Dominio;
using Dominio.Validation;
using FluentResults;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Core.Commands.CreatePassegger
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
    internal class CreatePassaggerHandler : ICommandHandler<CreatePasseggerCommand,Result<ResultPassegger>> 
    {
        public async Task<Result<ResultPassegger>> HandleAsync(CreatePasseggerCommand cmd, CancellationToken ct)
        {
                var newPassegger = new Passegger();
                newPassegger.SetPersonalInfomation(cmd.Nome, cmd.Cognome, cmd.Etá)
                .AddLuggage(cmd.Luggages)
                .SetTicket(cmd.TypeTicket);

                if (newPassegger.IsValid())
                    return Result.Ok(new ResultPassegger(newPassegger.Id));
                return Result.Fail("Impossibile creare il passeggero");
            }
    }
}
