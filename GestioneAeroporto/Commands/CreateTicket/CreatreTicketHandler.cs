using Dominio;
using Dominio.Validation;
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
            if (Route.Value.NSeatsLeft>0)
            {
                var NewTicket = new Ticket()
                {
                    TycketClassTicket = cmd.TypeTicket.ToString(),
                    Seat = Route.Value.NSeatsLeft
                };
                if (new TicketValidator().Validate(NewTicket).IsValid)
                {
                    var ResultOfNewTicket = await _repository.NewTicketToRoute(cmd.IdFlightRoute, NewTicket);
                    if (ResultOfNewTicket)
                        return Result.Ok(new TicketResult() { IdTicket = NewTicket.Id });
                }
                return Result.Fail("Impossibile creare un nuovo ticket");
            }
            return Result.Fail("Posti esauriti");
        }
    }
}
