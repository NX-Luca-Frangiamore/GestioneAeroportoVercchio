using Dominio;

namespace Core
{
    public interface IRepository
    {
         Task<Route> NewAccoutPassegger(Passegger person);
         Task<bool> DeleteAccoutPassegger(string id);
         Task<bool> ChangeAccoutPassegger(string id, Passegger person);
         Task<Route> NewRoute(Aereo aereo, City from, City to);
         Task<bool> DeleteRoute(Route route);
         Task<bool> ChangeRoute(string id, Route newRoute);
    }
}
