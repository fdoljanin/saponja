using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Post;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly SaponjaDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;
        public PostRepository(SaponjaDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }

        private ResponseResult GetPostIfAuthorized(int postId, out Post post)
        {
            post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId);
            var userId = _claimProvider.GetUserId();

            if (post is null || post.UserId != userId)
                return ResponseResult.Error("Invalid post");

            return ResponseResult.Ok;
        }

        public ResponseResult<Post> CreatePost(PostCreateModel model)
        {
            var shelterId = _claimProvider.GetUserId();

            var post = new Post
            {
                Title = model.Title,
                DateTime = DateTime.Now,
                UserId = shelterId,
                HasBeenApproved = false
            };

            _dbContext.Add(post);
            _dbContext.SaveChanges();

            var contentFilePath = post.Id + ".txt";
            post.ContentPath = contentFilePath;
            _dbContext.SaveChanges();

            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage\BlogContent\" + contentFilePath, model.Content);

            return new ResponseResult<Post>(post);
        }

        public ResponseResult RemovePost(int postId)
        {
            var findPostResult = GetPostIfAuthorized(postId, out var post);
            if (findPostResult.IsError)
                return ResponseResult.Error("Unauthorized");

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult AddPostPhoto(int postId, IFormFile postPhoto)
        {
            var findPostResult = GetPostIfAuthorized(postId, out var post);
            if (findPostResult.IsError)
                return ResponseResult.Error("Unauthorized");

            var postPhotoExtension = System.IO.Path.GetExtension(postPhoto.FileName);
            var postPhotoFilePath = post.Id + postPhotoExtension;

            post.PhotoPath = postPhotoFilePath;
            _dbContext.SaveChanges();

            var postPhotoFile = File.Create(@"C:\Users\Korisnik\Desktop\saponja\Storage\BlogPhotos\" + postPhotoFilePath);
            postPhoto.CopyTo(postPhotoFile);

            return ResponseResult.Ok;
        }
    }
}
