using System;
using Saponja.Domain.Helpers;

namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostPreviewModel
    {
        public PostPreviewModel(Data.Entities.Models.Post post)
        {
            Id = post.Id;
            Title = post.Title;
            PhotoPath = post.PhotoPath;
            Timestamp = post.DateTime;
            ContentPreview = FileHelpers.ReadFirstFewChars(post.ContentPath, 250);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentPreview { get; set; }
        public string PhotoPath { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
