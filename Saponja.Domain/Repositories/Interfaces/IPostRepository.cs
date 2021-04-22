using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IPostRepository
    {
        ResponseResult CreatePost(PostModel model, int shelterId);
        ResponseResult DeletePost(int shelterId);
        ICollection<PostModel> GetPosts();
        ResponseResult<PostModel> GetPost(int postId);
        ICollection<PostModel> GetTopThreePosts();
    }
}

