namespace Monster_Review_Store.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MonsterOwner> MonsterOwners { get; set; }
        public ICollection<MonsterCategory> MonsterCategories { get; set; }
    }
}
