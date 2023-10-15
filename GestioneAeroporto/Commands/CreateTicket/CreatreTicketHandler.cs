using Dominio;
using FluentResults;
using Microsoft.AspNetCore.Routing;
using SimpleSoft.Mediator;

namespace Core.Commands.CreateTicket
{
    public class CreatreTicketHandler:ICommandHandler<TicketCommand,Result<Ticket>>
    {
        private List<Ticket> Tickets;
        private int NTicketLeft;

        public async Task<Result<Ticket>> HandleAsync(TicketCommand cmd, CancellationToken ct)
        {
            if (NTicketLeft > cmd.NSeats)
            {
                var NewTicket = new Ticket();
                Tickets.Add(NewTicket);
                return Result.Ok(NewTicket);
            }
            return Result.Fail("Posti esauriti");
        }
    }
}
