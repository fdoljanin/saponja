using System.Linq;
using Saponja.Data.Entities;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Domain.Services.Implementations
{
    public class AccessValidator : IAccessValidator
    {
        private readonly SaponjaDbContext _dbContext;
        private readonly int _userId;

        public AccessValidator(SaponjaDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _userId = claimProvider.GetUserId();
        }

        public bool CheckAnimalAccess(int animalId)
        {
            var result = _dbContext.Animals
                .Any(a => !a.HasBeenAdopted && a.Id == animalId && a.ShelterId == _userId);

            return result;
        }

        public bool CheckNotificationAccess(int notificationId)
        {
            var result = _dbContext.Notifications
                .Any(n => n.Id == notificationId && n.UserId == _userId);

            return result;
        }

        public bool CheckAdopterAccess(int adopterId)
        {
            var result = _dbContext.Adopters
                .Any(a => a.Id == adopterId && a.Animal.ShelterId == _userId);

            return result;
        }

        public bool CheckPostAccess(int postId)
        {
            var result = _dbContext.Posts
                .Any(p => p.Id == postId && p.UserId == _userId);

            return result;
        }

        public (bool access, int id) CheckGalleryPhotoAccessAndGetId(string photoPath)
        {
            var photo = _dbContext.AnimalPhotos
                .FirstOrDefault(p => p.PhotoPath == photoPath && p.Animal.ShelterId == _userId);

            return photo is null ? (false, default) : (true, photo.Id);
        }
    }
}
