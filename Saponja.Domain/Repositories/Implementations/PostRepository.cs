using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Post;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly SaponjaDbContext _dbContext;

        public PostRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult EditPost(int postId, PostCreateModel model)
        {
            var post = _dbContext.Posts.Find(postId);

            post.Title = model.Title;

            var contentFilePath = @$"PostContent\{post.Id}.txt";
            post.ContentPath = contentFilePath;
            _dbContext.SaveChanges();

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", contentFilePath);
            File.WriteAllText(serverPath, model.Content);

            return new ResponseResult<Post>(post);
        }

        public ResponseResult<Post> CreatePost(PostCreateModel model)
        {
            var post = new Post
            {
                DateTime = DateTime.Now,
                UserId = model.UserId,
                HasBeenApproved = false
            };

            _dbContext.Add(post);
            _dbContext.SaveChanges();

            EditPost(post.Id, model);

            return new ResponseResult<Post>(post);
        }

        public ResponseResult RemovePost(int postId)
        {
            var post = _dbContext.Posts.Find(postId);

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult AddPostPhoto(int postId, IFormFile postPhoto)
        {
            var post = _dbContext.Posts.Find(postId);

            var postPhotoExtension = Path.GetExtension(postPhoto.FileName);
            var postPhotoFilePath = @$"PostPhoto\{post.Id}{postPhotoExtension}";

            post.PhotoPath = postPhotoFilePath;
            _dbContext.SaveChanges();

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", postPhotoFilePath);
            var postPhotoFile = File.Create(serverPath);
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

        public ResponseResult<PostModel> GetFullPost(int postId)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId && p.HasBeenApproved);

            if (post is null)
                return ResponseResult<PostModel>.Error("Post not found");

            var shelter = _dbContext.Shelters.FirstOrDefault(s => s.Id == post.UserId);
            var fullPost = new PostModel(post, shelter);

            return new ResponseResult<PostModel>(fullPost);
        }
    }
}
