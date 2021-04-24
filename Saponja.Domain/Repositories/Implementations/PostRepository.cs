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

        public ResponseResult EditPost(int postId, PostCreateModel model)
        {
            var findPostResult = GetPostIfAuthorized(postId, out var post);
            if (findPostResult.IsError)
                return ResponseResult.Error("Invalid post");

            post.Title = model.Title;

            var contentFilePath = post.Id + ".txt";
            post.ContentPath = contentFilePath;
            _dbContext.SaveChanges();

            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage\BlogContent\" + contentFilePath, model.Content);

            return new ResponseResult<Post>(post);
        }

        public ResponseResult<Post> CreatePost(PostCreateModel model)
        {
            var userId = _claimProvider.GetUserId();

            var post = new Post
            {
                DateTime = DateTime.Now,
                UserId = userId,
                HasBeenApproved = false
            };

            _dbContext.Add(post);
            EditPost(post.Id, model);

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

        public ResponseResult ApprovePost(int postId)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId && !p.HasBeenApproved);
            if (post is null)
                return ResponseResult.Error("Post not found!");

            post.HasBeenApproved = true;
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public PostListModel GetPostsPreview(int pageNumber)
        {
            var postsCount = _dbContext.Posts.Count();

            var postsList = _dbContext.Posts
                .Where(p => p.HasBeenApproved)
                .OrderByDescending(p => p.DateTime)
                .Skip(3 * pageNumber)
                .Take(3)
                .Select(p => new PostPreviewModel(p))
                .ToList();

            return new PostListModel
            {
                PostsCount = postsCount,
                Posts = postsList
            };
        }

        public ResponseResult<PostModel> GetFullPost (int postId)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId && p.HasBeenApproved);
        }
    }
}
