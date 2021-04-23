using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IPostRepository
    {
        ResponseResult<Post> CreatePost(PostCreateModel model);
        ResponseResult EditPost(int postId, PostCreateModel model);
        ResponseResult RemovePost(int postId);
        ResponseResult AddPostPhoto(int postId, IFormFile postPhoto);
    }
}

