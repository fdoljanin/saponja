using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostListModel
    {
        public int PostsCount { get; set; }
        public IEnumerable<PostPreviewModel> Posts { get; set; }
    }
}
