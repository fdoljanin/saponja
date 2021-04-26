using System;

namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostModel
    {
        public PostModel(Data.Entities.Models.Post post, Data.Entities.Models.Shelter shelter)
        {
            Title = post.Title;
            Content = System.IO.File.ReadAllText(post.ContentPath);
            PhotoPath = post.PhotoPath;
            Timestamp = post.DateTime;
            ShelterName = shelter.Name;
            ShelterId = shelter.Id;
        }

        public string Title;
        public string Content;
        public string PhotoPath;
        public DateTime Timestamp;
        public string ShelterName;
        public int ShelterId;
    }
}
