using System;
using System.Collections.Generic;
using Mvc5App.Domain.Entities;

namespace Mvc5App.Domain.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        AppDbContext appDbContext;

        public ManagerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Manager> Managers
        {
            get
            {
                return appDbContext.Managers;
            }
        }
    }
}
