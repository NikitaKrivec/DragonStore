using Monster_Review_Store.Data;
using Monster_Review_Store.Models;

namespace Monster_Review_Store
{
    public class Dragons
    {
        private readonly DataContext _context;
        public Dragons(DataContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            if (!_context.MonsterOwners.Any())
            {
                var dragonOwners = new List<MonsterOwner>()
                {
                    new MonsterOwner()
                    {
                        Monster = new Monster()
                        {
                            Name = "Viserion",
                            CreatedDate = new DateTime(80,6,9),
                            MonsterCategories = new List<MonsterCategory>()
                            {
                                new MonsterCategory { Category = new Category() { Name = "Fire"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Viserion",Text = "Viserion breathes fire", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                                new Review { Title="Viserion", Text = "The body of the dragon is covered with cream " +
                                "and gold scales, and its wings are red-orange.", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                                new Review { Title="Viserion",Text = "After the death, became the dragon King of the night", Mark = 1,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Daenerys",
                            LastName = "Targaryen",
                            Country = new Country()
                            {
                                Name = "Westeros"
                            }
                        }
                    },
                    new MonsterOwner()
                    {
                        Monster = new Monster()
                        {
                            Name = "Caraxes",
                            CreatedDate = new DateTime(80,1,1),
                            MonsterCategories = new List<MonsterCategory>()
                            {
                                new MonsterCategory { Category = new Category() { Name = "Fire"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Caraxes", Text = "Caraxes was red, huge, and lean", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                                new Review { Title= "Caraxes",Text = "He does love to burn.", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                                new Review { Title= "Caraxes", Text = "Caraxes was about half the size of the huge Vhagar", Mark = 1,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Daemon",
                            LastName = "Targaryen",
                            Country = new Country()
                            {
                                Name = "Westeros"
                            }
                        }
                    },
                    new MonsterOwner()
                    {
                        Monster = new Monster()
                        {
                            Name = "Vhagar",
                            CreatedDate = new DateTime(56,1,1),
                            MonsterCategories = new List<MonsterCategory>()
                            {
                                new MonsterCategory { Category = new Category() { Name = "Fire"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Vhagar",Text = "The color of Vhagar's scales, horns, wings, wing bones, and spinal crest.", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                                new Review { Title="Vhagar",Text = "Vhagar's breath was so hot that it could melt a knight's" +
                                " armor and cook him inside", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                                new Review { Title="Vhagar",Text = "Vhagar was the hardened survivor of a hundred battles, " +
                                "had grown almost as large as Balerion", Mark = 5,
                                Reviewer = new Reviewer(){ FirstName = "Nikita", LastName = "Krivec" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Aemond",
                            LastName = "Targaryen",
                            Country = new Country()
                            {
                                Name = "Westeros"
                            }
                        }
                    }
                };
                _context.MonsterOwners.AddRange(dragonOwners);
                _context.SaveChanges();
            }
        }
    }
}
