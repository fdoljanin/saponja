using System.Collections.Generic;

namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostListModel
    {
        public int PostsCount { get; set; }
        public IEnumerable<PostPreviewModel> Posts { get; set; }
    }
}
