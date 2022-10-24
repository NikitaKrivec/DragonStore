using Monster_Review_Store.Models;

namespace Monster_Review_Store.Interfaces
{
    public interface IDragonRepository
    {
        ICollection<Monster> GetMonsters(); // show a list of our products

        Monster GetMonster(int id);
        Monster GetMonster(string name);
        decimal GetMonsterRating(int dragonId);
        bool MonsterExists(int dragonId);
    }
}
