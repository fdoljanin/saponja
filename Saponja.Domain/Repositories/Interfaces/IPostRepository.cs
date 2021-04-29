using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Post;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IPostRepository
    {
        ResponseResult<Post> CreatePost(PostCreateModel model);
        ResponseResult EditPost(int postId, PostCreateModel model);
        ResponseResult RemovePost(int postId);
        ResponseResult AddPostPhoto(int postId, IFormFile postPhoto);
        ResponseResult ApprovePost(int postId);
        PostListModel GetPostsPreview(int pageNumber);
        ResponseResult<PostModel> GetFullPost(int postId);
    }
}

