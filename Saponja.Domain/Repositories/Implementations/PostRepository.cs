using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

        public ResponseResult CreatePost(PostModel model, int shelterId)
        {
            var post = new Post
            {
                Id = model.Id,
                Title = model.Title,
                DateTime = model.DateTime,
                ContentPath = model.ContentLink,
                ImagePath = model.ImageLink,
                UserId = shelterId
            };
            _dbContext.Add(post);
            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }

        public ResponseResult DeletePost(int postId)
        {
            var post = _dbContext.Posts.Find(postId);

            if (post is null)
                return ResponseResult.Error("Not found");

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult<PostModel> GetPost(int postId)
        {
            var post = _dbContext.Posts
                .Where(p => p.Id == postId)
                .Select(p => new PostModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    DateTime = p.DateTime,
                   /* ContentLink = p.ContentLink,
                    ImageLink = p.ImageLink,
                    ShelterName = p.UserId.Name*/
                })
                .SingleOrDefault();

            return post is null
                ? ResponseResult<PostModel>.Error("Not found")
                : new ResponseResult<PostModel>(post);
        }

        public ICollection<PostModel> GetPosts()
        {
            var posts = _dbContext.Posts
                .AsNoTracking()
                .Select(p => new PostModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    DateTime = p.DateTime,
                    /*ContentLink = p.ContentLink,
                    ImageLink = p.ImageLink*/
                })
                .ToList();

            return posts;
        }

        public ICollection<PostModel> GetTopThreePosts()
        {
            var posts = _dbContext.Posts
                .Select(p => new PostModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    DateTime = p.DateTime,
                    /*ContentLink = p.ContentLink,
                    ImageLink = p.ImageLink*/
                })
                .Take(3)
                .ToList();

            return posts;

        }
    }
}
