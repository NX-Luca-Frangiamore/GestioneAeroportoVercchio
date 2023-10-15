using Dominio;
using FluentResults;
using Microsoft.AspNetCore.Routing;
using SimpleSoft.Mediator;

namespace Core.Commands.CreateTicket
{
    public class CreatreTicketHandler:ICommandHandler<TicketCommand,Result<TicketResult>>
    {
        private readonly IRepository _repository;
        public CreatreTicketHandler(IRepository repository) {
            _repository = repository;        
        }

        public async Task<Result<TicketResult>> HandleAsync(TicketCommand cmd, CancellationToken ct)
        {
            var Route= await _repository.GetRoute(cmd.IdFlightRoute);
            //prendi valore nseatleft
            //if (NTicketLeft > cmd.NSeats)
            //{
            //    var NewTicket = new Ticket();
            //    Tickets.Add(NewTicket);
            //    return Result.Ok(NewTicket);
            //}
            return Result.Fail("Posti esauriti");
        }
    }
}
