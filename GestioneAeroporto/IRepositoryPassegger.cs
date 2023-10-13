using Domain;

namespace Core
{
    public interface IRepositoryPassegger
    {
         Task<Domain.Route> NewAccoutPassegger(Person person);
         Task<bool> DeleteAccoutPassegger(string id);
         Task<bool> ChangeAccoutPassegger(string id, Person person);
    }
}
