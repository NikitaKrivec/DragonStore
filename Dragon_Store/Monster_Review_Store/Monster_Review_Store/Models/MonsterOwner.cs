namespace Monster_Review_Store.Models
{
    public class MonsterOwner
    {
        public int MonsterId { get; set; }
        public int OwnerId { get; set; }
        public Monster Monster { get; set; }
        public Owner Owner { get; set; }
    }
}
