using Monster_Review_Store.Models;

namespace Monster_Review_Store.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfDragon(int dragonId);
        ICollection<Monster> GetDragonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool UdpateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool Save();
    }
}
