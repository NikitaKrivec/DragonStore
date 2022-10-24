namespace Monster_Review_Store.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MonsterCategory> MonsterCategories { get; set; }
    }
}
