using SimpleSoft.Mediator;
using Dominio;
using Dominio.Validation;
using FluentResults;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Routing;
using Core.Commands.CreateTicket;

namespace Core.Commands.CreatePassegger
{
    static class MethodToCreatePassegger
    {
        internal static Passegger SetPersonalInfomation(this Passegger p, string nome, string cognome, int Etá)
        {
            p.Name = nome;
            p.Cognome = cognome;
            p.Etá = Etá;
            return p;
        }
        internal static Passegger AddLuggage(this Passegger p, List<CreateLuggageCommand>? luggages)
        {
            if (luggages is null) return p;

            luggages.ForEach(l =>
            {
                var luggage = new Luggage
                {
                    Peso = l.Peso,
                    Dimensione = l.Dimensione,
                };
                p.Luggages.Add(luggage);

            });

            return p;
        }
        
    }
    internal class CreatePassaggerHandler : ICommandHandler<CreatePasseggerCommand, Result<ResultPassegger>>
    {
        private readonly IRepository _repository;
        private readonly Mediator _mediator;
        public CreatePassaggerHandler(IRepository repository, Mediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public async Task<Result<ResultPassegger>> HandleAsync(CreatePasseggerCommand cmd, CancellationToken ct)
        {
            var newPassegger = new Passegger();
            newPassegger.SetPersonalInfomation(cmd.Nome, cmd.Cognome, cmd.Etá)
            .AddLuggage(cmd.Luggages);
            if (newPassegger.IsValid())
            {
                return await AddNewPasseggerIfPossible(newPassegger, cmd.IdRoute,cmd.TypeTicket);
            }
            return Result.Fail("Impossibile creare il passeggero");

        }
        private async Task<Result<ResultPassegger>> AddNewPasseggerIfPossible(Passegger Passegger,string IdFlightRoute,TypeClassTicket typeClassTicket)
        {
            var ResultTicket = _mediator.Send(new TicketCommand(typeClassTicket,-1));
            if (ResultTicket.IsSuccess)
            {
                var ResultRoute = await _repository.NewPasseggerToRoute(IdFlightRoute, Passegger);
      
                {
                    if (ResultRoute.IsSuccess)
                        return Result.Ok(new ResultPassegger(Passegger.Id));
                }
                return Result.Fail("Impossibile inserire il passeggero");
            }
            return Result.Fail("Impossibile creare il ticket");
        }
    }
}
