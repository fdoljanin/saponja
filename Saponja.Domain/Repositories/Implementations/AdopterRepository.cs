using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class AdopterRepository : IAdopterRepository
    {
        private readonly SaponjaDbContext _dbContext;

        public AdopterRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
