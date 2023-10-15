using Core.Commands.CreatePassegger;
using Dominio;
using FluentResults;
using SimpleSoft.Mediator;

namespace Core.Commands.CreateTicket
{
    public class TicketCommand:Command<Result<Ticket>>
    {
        public TypeClassTicket TypeTicket { get; set; }
        public int NSeats { get; set; }
        public string Id { get; set; }
        public string IdFlightRoute { get; set; }
    }
    public enum TypeClassTicket
    {
        Second, Primary
    }
}
