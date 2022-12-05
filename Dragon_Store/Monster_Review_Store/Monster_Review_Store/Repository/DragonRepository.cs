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

        public bool CreateDragon(int ownerId, int categoryId, Monster dragon)
        {
            var dragonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var dragonOwner = new MonsterOwner()
            {
                Owner = dragonOwnerEntity,
                Monster = dragon,
            };

            _context.Add(dragonOwner);

            var dragonCategory = new MonsterCategory()
            {
                Category = category,
                Monsters = dragon,
            };

            _context.Add(dragonCategory);
            _context.Add(dragon);

            return Save();
        }

        public Monster GetDragon(int id)
        {
            return _context.Monster.Where(m => m.Id == id).FirstOrDefault();
        }

        public Monster GetDragon(string name)
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

        public ICollection<Monster> GetDragons()
        {
            return _context.Monster.OrderBy(m => m.Id).ToList();
        }

        public bool MonsterExists(int dragonId)
        {
            return _context.Monster.Any(m => m.Id == dragonId); 
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateDragon(int ownerId, int categoryId, Monster dragon)
        {
            _context.Update(dragon);
            return Save();
        }

        public bool DeleteDragon(Monster dragon)
        {
            _context.Remove(dragon);
            return Save();
        }
    }
}
