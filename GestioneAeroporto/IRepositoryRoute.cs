using Domain;

namespace Core
{
    public interface IRepository
    {
         Task<Domain.Route> NewRoute(Aereo aereo, City from, City to);
         Task<bool> DeleteRoute(Domain.Route route);
         Task<bool> ChangeRoute(string id, Domain.Route newRoute);
    }
}
