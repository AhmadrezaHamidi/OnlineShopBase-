namespace Domain.Entitites
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
