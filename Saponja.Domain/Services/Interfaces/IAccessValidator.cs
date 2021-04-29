namespace Saponja.Domain.Services.Interfaces
{
    public interface IAccessValidator
    {
        bool CheckAnimalAccess(int animalId);
        bool CheckNotificationAccess(int notificationId);
        bool CheckAdopterAccess(int adopterId);
        bool CheckPostAccess(int postId);
        (bool access, int id) CheckGalleryPhotoAccessAndGetId(string photoPath);
    }
}
