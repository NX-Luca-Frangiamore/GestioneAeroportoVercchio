using Dominio;
using FluentResults;
using Dominio.Passegger;
namespace Core
{
    public interface IRepositoryPassegger
    {
        Task<bool> AddNewPasseggerWithTicket(string idRoute, Passegger person);
        Task<bool> DeletePasseggerToRoute(string id);
        Task<bool> ChangePasseggerToRoute(string id, Passegger person);
    }
    public interface IRepositoryRoute
    {
        Task<Result<FlightRoute>> GetRoute(string idRoute);
        Task<bool> NewRoute(Aereo aereo, City from, City to);
        Task<bool> DeleteRoute(FlightRoute route);
        Task<bool> ChangeRoute(string id, FlightRoute newRoute);
    }
    public interface IRepositoryTicket
    {    
         Task<bool> NewTicketToRoute(string idRoute,Ticket ticket);
         Task<bool> DeleteTicketToRoute(string idTicket);
    
    }
}
