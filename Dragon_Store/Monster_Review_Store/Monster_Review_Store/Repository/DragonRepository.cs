using Monster_Review_Store.Data;
using Monster_Review_Store.Interfaces;
using Monster_Review_Store.Models;

namespace Monster_Review_Store.Repository
{
    public class DragonRepository : IDragonRepository
    {
        private readonly DataContext _context;
        public DragonRepository(DataContext context)
        {
            _context = context;
        }

        public Monster GetMonster(int id)
        {
            return _context.Monster.Where(m => m.Id == id).FirstOrDefault();
        }

        public Monster GetMonster(string name)
        {
            return _context.Monster.Where(m => m.Name == name).FirstOrDefault();
        }

        public decimal GetMonsterRating(int dragonId)
        {
            var review = _context.Reviews.Where(m => m.Monster.Id == dragonId);

            if (review.Count() <= 0) 
                return 0;

            return ((decimal)review.Sum(r => r.Mark) / review.Count());
        }

        public ICollection<Monster> GetMonsters()
        {
            return _context.Monster.OrderBy(m => m.Id).ToList();
        }

        public bool MonsterExists(int dragonId)
        {
            return _context.Monster.Any(m => m.Id == dragonId); 
        }
    }
}
