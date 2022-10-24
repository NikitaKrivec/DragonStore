using Monster_Review_Store.Data;
using Monster_Review_Store.Interfaces;
using Monster_Review_Store.Models;

namespace Monster_Review_Store.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Monster> GetDragonByCategory(int categoryId)
        {
            return _context.MonsterCategories.Where(e => e.CategoryId == categoryId).Select(d => d.Monsters).ToList();
        }
    }
}
