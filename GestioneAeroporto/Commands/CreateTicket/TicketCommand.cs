using Core.Commands.CreatePassegger;
using Dominio;
using FluentResults;
using SimpleSoft.Mediator;

namespace Core.Commands.CreateTicket
{
    public class TicketCommand:Command<Result<Ticket>>
    {
        public TypeClassTicket TypeClassTicket { get; set; }
        public int NSeats { get; set; }
        public TicketCommand(TypeClassTicket typeClassTicket, int nSeats)
        {
            TypeClassTicket = typeClassTicket;
            NSeats = nSeats;
        }
    }
    public enum TypeClassTicket
    {
        Second, Primary
    }
}
