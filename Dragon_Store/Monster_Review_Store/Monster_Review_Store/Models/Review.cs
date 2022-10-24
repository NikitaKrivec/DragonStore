namespace Monster_Review_Store.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public Reviewer Reviewer { get; set; }
        public Monster Monster { get; set; }

    }
}
