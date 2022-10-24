using Monster_Review_Store.Models;

namespace Monster_Review_Store.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Monster> GetDragonByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
