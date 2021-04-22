using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Adopter;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IAdopterRepository
    {
        ResponseResult ApplyForAnimal(AdopterApplyModel model);
        ResponseResult ConfirmEmail(string confirmationToken);
        ResponseResult RefuseAdopter(int adopterId);
        ResponseResult SetAnimalAdopter(int adopterId);
        ResponseResult SetAnimalAdoptedOutside(int animalId);

    }
}
