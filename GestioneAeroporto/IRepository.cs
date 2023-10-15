using Dominio;
using FluentResults;

namespace Core
{
    public interface IRepository
    {
         Task<Result<FlightRoute>> NewPasseggerToRoute(string idRoute,Passegger person);
         Task<bool> DeletePasseggerToRoute(string id);
         Task<bool> ChangePasseggerToRoute(string id, Passegger person);
        Task<Result<Ticket>> NewTicketToRoute(string idRoute);
        Task<bool> DeleteTicketToRoute(string idTicket);
        Task<Result<FlightRoute>> NewRoute(Aereo aereo, City from, City to);
         Task<bool> DeleteRoute(FlightRoute route);
         Task<bool> ChangeRoute(string id, FlightRoute newRoute);
    }
}
