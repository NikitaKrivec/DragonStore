using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace Monster_Review_Store.Models
{
    public class MonsterCategory
    {
        public int MonsterId { get; set; }
        public int CategoryId { get; set; }
        public Monster Monsters { get; set; }
        public Category Category { get; set; }
    }
}
