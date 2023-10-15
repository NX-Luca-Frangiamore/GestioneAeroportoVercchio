using Dominio;
using FluentResults;
using Dominio.Passegger;
namespace Core
{
    public interface IRepository
    {
        Task<Result<Route>> GetRoute(string idRoute);
        Task<bool> AddNewPasseggerToRoute(string idRoute,Passegger person);
         Task<bool> DeletePasseggerToRoute(string id);
         Task<bool> ChangePasseggerToRoute(string id, Passegger person);
         Task<bool> NewTicketToRoute(string idRoute);
         Task<bool> DeleteTicketToRoute(string idTicket);
         Task<bool> NewRoute(Aereo aereo, City from, City to);
         Task<bool> DeleteRoute(FlightRoute route);
         Task<bool> ChangeRoute(string id, FlightRoute newRoute);
    }
}
