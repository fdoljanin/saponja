using System;
using System.IO;

namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostModel
    {
        public PostModel(Data.Entities.Models.Post post, Data.Entities.Models.Shelter shelter)
        {
            Title = post.Title;
            PhotoPath = post.PhotoPath;
            Timestamp = post.DateTime;
            ShelterName = shelter.Name;
            ShelterId = shelter.Id;

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", post.ContentPath);
            Content = File.ReadAllText(serverPath);
        }

        public string Title;
        public string Content;
        public string PhotoPath;
        public DateTime Timestamp;
        public string ShelterName;
        public int ShelterId;
    }
}
