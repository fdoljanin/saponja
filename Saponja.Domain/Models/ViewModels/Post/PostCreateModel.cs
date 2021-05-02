namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostCreateModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
