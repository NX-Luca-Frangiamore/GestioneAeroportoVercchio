using SimpleSoft.Mediator;
using Dominio;
using Dominio.Validation;
using FluentResults;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Routing;
using Core.Commands.CreateTicket;
using Dominio.Passegger;
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
        private readonly IRepositoryPassegger _repository;
        private readonly Mediator _mediator;
        public CreatePassaggerHandler(IRepositoryPassegger repository, Mediator mediator)
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
                var ResultTicket = CreateTicket(cmd);
                if (ResultTicket.IsSuccess)
                    return await LinkPasseggerToTicket(newPassegger, ResultTicket.Value.IdTicket);
                return Result.Fail("Impossibile creare il ticket");
            }
            return Result.Fail("Impossibile creare il passeggero");

        }

        private Result<TicketResult> CreateTicket(CreatePasseggerCommand cmd)
        {
            var cmdTicket = new TicketCommand
            {
                IdFlightRoute = cmd.IdRoute,
                TypeTicket = cmd.TypeTicket
            };
            var Ticket = _mediator.Send(cmdTicket);
            return Ticket;
        }

        private async Task<Result<ResultPassegger>> LinkPasseggerToTicket(Passegger Passegger, string idTicket)
        {
                var ResultRoute = await _repository.AddNewPasseggerWithTicket(idTicket, Passegger);     
                {
                    if (ResultRoute)
                        return Result.Ok(new ResultPassegger(Passegger.Id));
                }
                return Result.Fail("Impossibile inserire il passeggero");  
        }
    }
}
