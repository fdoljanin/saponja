using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly SaponjaDbContext _dbContext;

        public AnimalRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
