using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly SaponjaDbContext _dbContext;
        public NotificationRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
