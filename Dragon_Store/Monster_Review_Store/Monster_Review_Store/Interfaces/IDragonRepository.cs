using Monster_Review_Store.Models;

namespace Monster_Review_Store.Interfaces
{
    public interface IDragonRepository
    {
        ICollection<Monster> GetDragons(); // show a list of our products
        Monster GetDragon(int id);
        Monster GetDragon(string name);
        decimal GetMonsterRating(int dragonId);
        bool MonsterExists(int dragonId);
        bool CreateDragon(int ownerId, int categoryId, Monster dragon);
        bool UpdateDragon(int ownerId, int categoryId, Monster dragon);
        bool DeleteDragon(Monster dragon);
        bool Save();
    }
}
