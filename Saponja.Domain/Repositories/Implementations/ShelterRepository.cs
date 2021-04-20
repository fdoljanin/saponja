using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly SaponjaDbContext _dbContext;
        public ShelterRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
